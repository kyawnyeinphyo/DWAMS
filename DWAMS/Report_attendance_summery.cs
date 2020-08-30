using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DWAMS
{
    public partial class Report_attendance_summery : Form
    {
        public Report_attendance_summery()
        {
            InitializeComponent();
        }

        private void Report_attendance_summery_Load(object sender, EventArgs e)
        {
            this.spdAttendanceSummeryTableAdapter.Fill(this.DataSet_Report_Viewer.spdAttendanceSummery, System.DateTime.Today.Month, System.DateTime.Today.Year);
            this.rpvAttendance_summery.RefreshReport();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.spdAttendanceSummeryTableAdapter.Fill(this.DataSet_Report_Viewer.spdAttendanceSummery, dtpkDate.Value.Month, dtpkDate.Value.Year);
            this.rpvAttendance_summery.RefreshReport();
        }
    }
}