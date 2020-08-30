using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DWAMS_BLL;

namespace DWAMS
{
    public partial class Report_Staff : Form
    {
        public Report_Staff()
        {
            InitializeComponent();
        }

        #region myMethod

        private void cboDepartmentBind()
        {
            DepartmentController controller = new DepartmentController();
            DepartmentCollection collection = controller.SelectController();

            cboDepartment.DataSource = collection;
            cboDepartment.DisplayMember = "Depname";
            cboDepartment.ValueMember = "DepId";
        }

        private void cboPositionBind()
        {
            if (cboDepartment.Items.Count > 0)
            {
                PositionController controller = new PositionController();
                PositionCollection collection = controller.SelectController(cboDepartment.SelectedValue.ToString());

                cboPosition.Text = string.Empty; // becase there will be remained txt in cbo

                cboPosition.DataSource = collection;
                cboPosition.DisplayMember = "Position";
                cboPosition.ValueMember = "PositionID";
            }
        }

        #endregion

        private void FrmStaffReport_Load(object sender, EventArgs e)
        {

            cboDepartmentBind();
            cboPositionBind();

            rpvStaff_by_department.Visible = false;
            rpvStaff_position.Visible = false;
            rpvStaff.Visible = true;

            this.spdStaffSelectTableAdapter.Fill_Staff(this.DataSet_Report_Viewer.spdStaffSelect);
            rpvStaff.RefreshReport();
            this.rpvStaff.RefreshReport();
        }

        private void cboDepartment_DropDownClosed(object sender, EventArgs e)
        {
            rpvStaff_by_department.Visible = true;
            rpvStaff_position.Visible = false;
            rpvStaff.Visible = false;

            if (cboDepartment.Items.Count > 0)
            {
                this.staff_by_departmentTableAdapter.Fill_Staff_by_department(this.DataSet_Report_Viewer.staff_by_department, cboDepartment.SelectedValue.ToString());
                this.rpvStaff_by_department.RefreshReport();
                cboPositionBind();
            }

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            rpvStaff_by_department.Visible = false;
            rpvStaff_position.Visible = false;
            rpvStaff.Visible = true;

            this.spdStaffSelectTableAdapter.Fill_Staff(this.DataSet_Report_Viewer.spdStaffSelect);
            rpvStaff.RefreshReport();
        }

        private void cboPosition_DropDownClosed(object sender, EventArgs e)
        {
            if (cboPosition.Items.Count > 0)
            {
                rpvStaff_by_department.Visible = false;
                rpvStaff_position.Visible = true;
                rpvStaff.Visible = false;

                this.staff_by_positionTableAdapter.Fill(this.DataSet_Report_Viewer.staff_by_position, cboDepartment.SelectedValue.ToString(), cboPosition.SelectedValue.ToString());
                this.rpvStaff_position.RefreshReport();
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //changed
            //rpvStaff_by_department.Visible = true;
            //rpvStaff_position.Visible = false;
            //rpvStaff.Visible = false;

            //if (cboDepartment.Items.Count > 0)
            //{
            //    this.staff_by_departmentTableAdapter.Fill_Staff_by_department(this.DataSet_Report_Viewer.staff_by_department, cboDepartment.SelectedValue.ToString());
            //    this.rpvStaff_by_department.RefreshReport();
            //    cboPositionBind();
            //}
        }

        private void cboPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////changed
            //if (cboPosition.Items.Count > 0)
            //{
            //    rpvStaff_by_department.Visible = false;
            //    rpvStaff_position.Visible = true;
            //    rpvStaff.Visible = false;

            //    this.staff_by_positionTableAdapter.Fill(this.DataSet_Report_Viewer.staff_by_position, cboDepartment.SelectedValue.ToString(), cboPosition.SelectedValue.ToString());
            //    this.rpvStaff_position.RefreshReport();
            //}
        }
    }
}