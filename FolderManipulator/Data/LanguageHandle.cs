using FolderManipulator.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.Data
{
    public class LanguageHandle
    {
        private string[] nameExceptions = new string[] { "drpd_main_ordertype", "drpd_sub_ordertype", "status_strip", "toolstrip_menu", };

        private Form targetForm;
        private MenuStrip targetMenuStrip;

        public string FormName { get { return targetForm.Name; } }

        public LanguageHandle(Form form)
        {
            this.targetForm = form;
        }

        public LanguageHandle(Form form, MenuStrip targetMenuStrip)
        {
            this.targetForm = form;
            this.targetMenuStrip = targetMenuStrip;
        }

        public void LoadLanguageListToForm(LanguageDataList languageDataList)
        {
            if (targetForm == null)
                return;

            List<Control> controls = targetForm.GetControls();
            List<ToolStripItem> toolStripItems = null;
            if (targetMenuStrip != null)
                toolStripItems = targetMenuStrip.GetToolStripItems();
            foreach (LanguageData data in languageDataList.languageDatas)
            {
                int index = controls.FindIndex(x => x.Name == data.Name);
                if (index >= 0)
                {
                    controls[index].Text = data.Text;
                    continue;
                }
                if (toolStripItems != null)
                {
                    index = toolStripItems.FindIndex(x => x.Name == data.Name);
                    if (index >= 0)
                    {
                        toolStripItems[index].Text = data.Text;
                        continue;
                    }
                }
            }
        }

        public LanguageDataList MakeLangugaeListsFromCurrentFormData()
        {
            List<LanguageData> languageList = new List<LanguageData>();
            if (targetForm != null)
            {
                foreach (Control control in targetForm.GetControls())
                {
                    if (!string.IsNullOrEmpty(control.Text) && !nameExceptions.Contains(control.Name))
                    {
                        LanguageData languageData = new LanguageData(control.Name, control.Text);
                        languageList.Add(languageData);
                    }
                }
            }
            if (targetMenuStrip != null)
            {
                foreach (ToolStripItem toolStripItem in targetMenuStrip.GetToolStripItems())
                {
                    if (!string.IsNullOrEmpty(toolStripItem.Text) && !nameExceptions.Contains(toolStripItem.Name))
                    {
                        LanguageData languageData = new LanguageData(toolStripItem.Name, toolStripItem.Text);
                        languageList.Add(languageData);
                    }
                }
            }

            languageList.Sort();
            LanguageDataList languageDataList = new LanguageDataList(LanguageType.English, languageList);
            return languageDataList;
        }
    }
}
