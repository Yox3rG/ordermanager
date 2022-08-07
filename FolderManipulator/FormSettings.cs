using FolderManipulator.Analytics;
using FolderManipulator.Data;
using FolderManipulator.FolderRelated;
using FolderManipulator.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator
{
    public partial class FormSettings : Form
    {
        public Action<int> OnFontValueChanged;
        public Func<bool> OnTrySave;

        private int oldValue;
        LocalSettingsData targetLocalSettingsData;

        public FormSettings()
        {
            InitializeComponent();
        }

        public void SetTarget(LocalSettingsData localSettingsData)
        {
            targetLocalSettingsData = localSettingsData;
            oldValue = localSettingsData.OrdersFontPixelSize;
            FillData(localSettingsData);

        }

        public void FillData(LocalSettingsData localSettingsData)
        {
            try
            {
                txt_new_font_size.TextChanged -= txt_new_count_TextChanged;
                txt_new_font_size.Text = localSettingsData.OrdersFontPixelSize.ToString();
            }
            catch (Exception e)
            {
                AppConsole.WriteLine(e.Message);
            }
            finally
            {
                txt_new_font_size.TextChanged += txt_new_count_TextChanged;
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
                StatusManager.ShowMessage("Can't edit settings currently, try again later!", StatusColorType.Error, DelayTimeType.Medium);
                MessageBox.Show("Can't edit settings currently, try again later!");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            OnFontValueChanged?.Invoke(oldValue);
            Close();
        }

        private void txt_new_count_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(txt_new_font_size.Text, out int fontSize))
            {
                OnFontValueChanged?.Invoke(fontSize);
            }
        }
    }
}
