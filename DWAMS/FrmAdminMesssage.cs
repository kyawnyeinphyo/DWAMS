using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DWAMS
{
    public partial class FrmAdminMesssage : Form
    {
        private const string FILE_LOCATION = @"MSG.ams";

        public FrmAdminMesssage()
        {
            InitializeComponent();
        }

        #region myMethod

        private void ReadFile()
        {
            if (File.Exists(FILE_LOCATION))
            {
                using (StreamReader streamReader = new StreamReader(FILE_LOCATION))
                {
                    rtxtMessage.Text = streamReader.ReadToEnd();
                }
            }
        }

        private void SaveFile()
        {
                using (StreamWriter outputFile = new StreamWriter(FILE_LOCATION))//==>,true
                {
                    outputFile.WriteLine(rtxtMessage.Text);
                }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
            Globalizer.ShowMessage(Globalizer.MessageType.Information, "Save Successfully");
        }

        private void FrmAdminMesssage_Load(object sender, EventArgs e)
        {
            ReadFile();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            switch (btnShow.Text)
            {
                case "Show":
                    ReadFile();
                    btnShow.Text = "Hide";
                    break;

                case "Hide":
                    rtxtMessage.Text = string.Empty;
                    btnShow.Text = "Show";
                    break;
            }
        }

        private void pnl1_SizeChanged(object sender, EventArgs e)
        {
            Utilities.CenterMyControl(pnlButton);
        }
    }
}