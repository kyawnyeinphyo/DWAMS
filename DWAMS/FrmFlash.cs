using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace DWAMS
{
    public partial class FrmFlash : Form
    {

        public FrmFlash()
        {
            InitializeComponent();
        }

        private void Open_attendance_entry(object obj)
        {
            FrmAttendanceEntry a = new FrmAttendanceEntry(false);
            Application.Run(a);
        }

        private void Open_register_company(object obj)
        {
            FrmRegisterCompany cn = new FrmRegisterCompany();
            Application.Run(cn);
        }

        private void FrmFlash_Load(object sender, EventArgs e)
        {
            Utilities.CenterMyControl(lblTitle);
            timer1.Interval= 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.005;
            }
            else
            {
                this.Close();
                Thread th;

                if (File.Exists("Register.ams"))
                {
                     th = new Thread(Open_attendance_entry);
                }
                else
                {
                    th = new Thread(Open_register_company);
                }
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }
    }
}