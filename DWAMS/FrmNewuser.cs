using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DWAMS
{
    public partial class FrmNewuser : Form
    {

        public FrmNewuser()
        {
            InitializeComponent();
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            FrmAddress a = new FrmAddress();
            a.ShowDialog();

            btnDepartment.Enabled = true;
            SendKeys.Send("{Tab}");
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            FrmDepartment a = new FrmDepartment();
            a.ShowDialog();

            btnPosition.Enabled = true;
            SendKeys.Send("{Tab}");
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            FrmPosition a = new FrmPosition();
            a.ShowDialog();

            btnStaff.Enabled = true;
            SendKeys.Send("{Tab}");
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            FrmStaff a = new FrmStaff();
            a.ShowDialog();

            btnConfigure.Enabled = true;
            SendKeys.Send("{Tab}");
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            FrmDutyTime a = new FrmDutyTime();
            a.ShowDialog();

            btnRegister.Enabled = true;
            SendKeys.Send("{Tab}");
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Utilities.ShowMessage(Utilities.MessageType.Information, "Congratrulations!\nYou can start using the software...\nThank you...");
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegister a = new FrmRegister();
            a.ShowDialog();

            btnFinish.Enabled = true;
            SendKeys.Send("{Tab}");
        }
    }
}