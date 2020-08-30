using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DWAMS
{
    public partial class Report_monthly_payroll : Form
    {
        public Report_monthly_payroll()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.spdSalaryPaymentSelectTableAdapter.Fill(this.DataSet_Report_Viewer.spdSalaryPaymentSelect, dtpkDate.Value.Month, dtpkDate.Value.Year);

            this.rpvPayroll.RefreshReport();
        }

        private void Report_monthly_payroll_Load(object sender, EventArgs e)
        {
            this.spdSalaryPaymentSelectTableAdapter.Fill(this.DataSet_Report_Viewer.spdSalaryPaymentSelect, System.DateTime.Today.Month, System.DateTime.Today.Year);

            this.rpvPayroll.RefreshReport();
        }
    }
}