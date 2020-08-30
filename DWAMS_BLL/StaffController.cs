using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DWAMS_DAL;
using System.Data;

namespace DWAMS_BLL
{
    public class StaffController
    {
        StaffDataController datacontroller;
        private int count;
	   
        public StaffController()
        {
            datacontroller = new StaffDataController();
        }

        public void InsertController(StaffInfo info)
        {
            datacontroller.Insert(info.PositionID, info.AddID, info.DepID,  info.StaffCode, info.StaffName, info.StaffPhone, info.BasicSalary, info.HireDate, info.StaffDesp);
        }

        public void UpdateController(StaffInfo info)
        {
            datacontroller.Update(info.StaffId, info.PositionID, info.AddID, info.DepID, info.StaffCode, info.StaffName, info.StaffPhone, info.BasicSalary, info.HireDate, info.StaffDesp);
        }

        public void DeleteController(string staffid)
        {
            datacontroller.Delete(staffid);
        }

        public StaffCollection SelectController()
        {
            StaffCollection collection = new StaffCollection();
            IDataReader reader = datacontroller.SelectList();

            count = 0;

            while (reader.Read())
            {
                StaffInfo info = new StaffInfo();

                info.StaffId = Convert.ToString(reader["StaffId"]);
                info.PositionID = Convert.ToString(reader["PositionId"]);
                info.DepID = Convert.ToString(reader["DepId"]);
                info.AddID = Convert.ToString(reader["AddressId"]);
                info.StaffCode = Convert.ToString(reader["StaffCode"]);
                info.StaffName = Convert.ToString(reader["StaffName"]);
                info.StaffPhone = Convert.ToString(reader["StaffPh"]);
                info.BasicSalary = Convert.ToDouble(reader["BasicSalary"]);
                info.HireDate = Convert.ToDateTime(reader["HireDate"]);
                info.StaffDesp = Convert.ToString(reader["Desp"]);
                info.Position = Convert.ToString(reader["Position"]);
                info.Depname = Convert.ToString(reader["DepName"]);
                info.Addressname = Convert.ToString(reader["AddressName"]);
                info.No = Convert.ToString(++count);
                collection.Add(info);
            }
            reader.Close();

            return collection;
        }

        public StaffCollection SelectController(string staffid)
        {
            StaffCollection collection = new StaffCollection();
            IDataReader reader = datacontroller.SelectList(staffid);

            count = 0;

            while (reader.Read())
            {
                StaffInfo info = new StaffInfo();

                info.StaffId = Convert.ToString(reader["StaffId"]);
                info.PositionID = Convert.ToString(reader["PositionId"]);
                info.DepID = Convert.ToString(reader["DepId"]);
                info.AddID = Convert.ToString(reader["AddressId"]);
                info.StaffCode = Convert.ToString(reader["StaffCode"]);
                info.StaffName = Convert.ToString(reader["StaffName"]);
                info.StaffPhone = Convert.ToString(reader["StaffPh"]);
                info.BasicSalary = Convert.ToDouble(reader["BasicSalary"]);
                info.HireDate = Convert.ToDateTime(reader["HireDate"]);
                info.StaffDesp = Convert.ToString(reader["Desp"]);
                info.Position = Convert.ToString(reader["Position"]);
                info.Depname = Convert.ToString(reader["DepName"]);
                info.Addressname = Convert.ToString(reader["AddressName"]);
                info.No = Convert.ToString(++count);
                collection.Add(info);
            }
            reader.Close();

            return collection;
        }

        public StaffInfo StaffSelectbyStaffId(string staffid)
        {
            IDataReader reader = datacontroller.StaffSelectbyStaffId(staffid);
            StaffInfo info = new StaffInfo();

            while (reader.Read())
            {
                info.StaffId = Convert.ToString(reader["StaffId"]);
                info.StaffCode = Convert.ToString(reader["StaffCode"]);
                info.StaffName = Convert.ToString(reader["StaffName"]);

            }
            reader.Close();

            return info;
        }

        public StaffInfo StaffSelectbyStaffCode(string staffcode)
        {
            IDataReader reader = datacontroller.StaffSelectbyStaffCode(staffcode);
            StaffInfo info = new StaffInfo();

            while (reader.Read())
            {
                info.StaffId = Convert.ToString(reader["StaffId"]);
                info.StaffCode = Convert.ToString(reader["StaffCode"]);
                info.StaffName = Convert.ToString(reader["StaffName"]);
                info.Position = Convert.ToString(reader["Position"]);
                info.Depname = Convert.ToString(reader["DepName"]);
                info.Addressname = Convert.ToString(reader["AddressName"]);

            }
            reader.Close();

            return info;
        }

    }

    public class StaffInfo
    {
        private string staffId;
        private string positionID;
        private string addID; 
        private string depID;
        private byte[] profilePic;
        private string staffCode;
        private string staffName; 
        private string staffPhone;
        private double basicSalary;
        private DateTime hireDate;
        private string staffDesp;
        private string addressname;
        private string depname;
        private string position,
            no;

        private int totallate,
            totalearly,
            absentday;

        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public int Absentday
        {
            get { return absentday; }
            set { absentday = value; }
        }

        public int Totalearly
        {
            get { return totalearly; }
            set { totalearly = value; }
        }

        public int Totallate
        {
            get { return totallate; }
            set { totallate = value; }
        }

        public string Addressname
        {
            get { return addressname; }
            set { addressname = value; }
        }

        public string Depname
        {
            get { return depname; }
            set { depname = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public byte[] ProfilePic
        {
            get { return profilePic; }
            set { profilePic = value; }
        }

        public string StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }

        public string PositionID
        {
            get { return positionID; }
            set { positionID = value; }
        }

        public string DepID
        {
            get { return depID; }
            set { depID = value; }
        }
       

        public string AddID
        {
            get { return addID; }
            set { addID = value; }
        }
       
        public string StaffCode
        {
            get { return staffCode; }
            set { staffCode = value; }
        }

        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }

        public string StaffPhone
        {
            get { return staffPhone; }
            set { staffPhone = value; }
        }

        public string StaffDesp
        {
            get { return staffDesp; }
            set { staffDesp = value; }
        }

        public double BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }

        public DateTime HireDate
        {
            get { return hireDate; }
            set { hireDate = value; }
        }

    }

    public class StaffCollection:Collection<StaffInfo>
    {
    }
}
