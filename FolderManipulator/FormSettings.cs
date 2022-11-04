using FolderManipulator.Analytics;
using FolderManipulator.Data;
using FolderManipulator.FolderRelated;
using FolderManipulator.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator
{
    public partial class form_settings : Form
    {
        public Action<int> OnFontValueChanged;
        public Action<int> OnOrderNameMaxLengthChanged;
        public Action<string> OnLocalDriveLetterChanged;
        public Func<bool> OnTrySave;

        private int oldFontValue;
        private int oldMaxLength;
        private string oldDriveLetter;
        LocalSettingsData targetLocalSettingsData;

        public string CurrentVersion
        {
            get
            {
                return ApplicationDeployment.IsNetworkDeployed
                       ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                       : Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public form_settings()
        {
            InitializeComponent();
            TrySetVersionNumber();
        }

        private void TrySetVersionNumber()
        {
            try
            {
                lbl_version_number.Text = CurrentVersion;
            }
            catch (Exception e)
            {
                StatusManager.ShowMessage("cantShowVersionNumber", StatusColorType.Warning, DelayTimeType.Medium);
                AppConsole.WriteLine(e.Message);
                throw;
            }
        }

        public void SetTarget(LocalSettingsData localSettingsData)
        {
            targetLocalSettingsData = localSettingsData;
            oldFontValue = localSettingsData.OrdersFontPixelSize;
            oldMaxLength = localSettingsData.OrderNameMaxLength;
            oldDriveLetter = localSettingsData.LocalDriveLetter;
            FillData(localSettingsData);
        }

        public void FillData(LocalSettingsData localSettingsData)
        {
            FillField(txt_new_font_size, txt_new_font_size_TextChanged, localSettingsData.OrdersFontPixelSize.ToString());
            FillField(txt_drive_letter, txt_drive_letter_TextChanged, localSettingsData.LocalDriveLetter);
            FillField(txt_order_max_length, txt_drive_letter_TextChanged, localSettingsData.OrderNameMaxLength.ToString());
        }

        private void FillField(TextBox textBox, EventHandler onChangeEvent, string text)
        {
            try
            {
                textBox.TextChanged -= onChangeEvent;
                textBox.Text = text;
            }
            catch (Exception e)
            {
                AppConsole.WriteLine(e.Message);
            }
            finally
            {
                textBox.TextChanged += onChangeEvent;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            bool saveSuccess;
            saveSuccess = OnTrySave();

            if (saveSuccess)
            {
                Close();
            }
            else
            {
                StatusManager.ShowMessage("cantEditSettings", StatusColorType.Error, DelayTimeType.Medium);
                MessageBox.Show(ErrorManager.GetCurrentErrorMessage("cantEditSettings"));
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            OnFontValueChanged?.Invoke(oldFontValue);
            OnLocalDriveLetterChanged?.Invoke(oldDriveLetter);
            OnOrderNameMaxLengthChanged?.Invoke(oldMaxLength);
            Close();
        }

        private void txt_new_font_size_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(txt_new_font_size.Text, out int fontSize))
            {
                OnFontValueChanged?.Invoke(fontSize);
            }
        }

        private void txt_drive_letter_TextChanged(object sender, EventArgs e)
        {
            OnLocalDriveLetterChanged?.Invoke(txt_drive_letter.Text);
        }

        private void txt_order_max_length_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(txt_order_max_length.Text, out int maxLength))
            {
                OnOrderNameMaxLengthChanged?.Invoke(maxLength);
            }
        }
    }
}
