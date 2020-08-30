using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DWAMS_DAL;
using System.Data;

namespace DWAMS_BLL
{
    public  class AbsentController
    {
        AbsentDataAccess dataAccess;
        AbsentCollection collection;
        IDataReader reader;
        AbsentInfo info;

        StaffDataController dataController;

        public AbsentController()
        {
            dataController = new StaffDataController();
            dataAccess = new AbsentDataAccess();
        }

        public void InsertToAbsent(DateTime absentdate)
        {
            reader = dataController.SelectStaff();

            while (reader.Read())
            {
                dataAccess.InsertToAbsent(Convert.ToString(reader["StaffId"]), absentdate);
            }
            reader.Close();
        }

        public AbsentCollection SelectAbsent(int month, int year)
        {
            collection = new AbsentCollection();
            reader = dataAccess.SelectAbsent(month, year);
            int count = 0;
            while (reader.Read())
            {
                info = new AbsentInfo();

                info.AbsentID = Convert.ToString(reader["AbsentId"]);
                info.StaffID = Convert.ToString(reader["Staffid"]);
                info.Absentdate = Convert.ToDateTime(reader["Absentdate"]);
                info.Staffcode = Convert.ToString(reader["Staffcode"]);
                info.Staffname = Convert.ToString(reader["Staffname"]);
                info.Staffphone = Convert.ToString(reader["Staffph"]);
                info.Department = Convert.ToString(reader["Depname"]);
                info.Position = Convert.ToString(reader["Position"]);
                info.No = Convert.ToString(++count);

                collection.Add(info);
            }
            reader.Close();

            return collection;
        }

        public void UpdateAbsent(string staffid, DateTime absentdate)
        {
            dataAccess.UpdateToAbsent(staffid, absentdate);
        }

    }

    public class AbsentInfo
    {
        private string absentID;
        private string staffID;
        private DateTime absentdate;
        private string staffcode,
            staffname,
            staffphone,
            position,
            department,
            no;

        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Staffphone
        {
            get { return staffphone; }
            set { staffphone = value; }
        }

        public string Staffname
        {
            get { return staffname; }
            set { staffname = value; }
        }

        public string Staffcode
        {
            get { return staffcode; }
            set { staffcode = value; }
        }

        public string AbsentID
        {
            get { return absentID; }
            set { absentID = value; }
        }

        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }

        public DateTime Absentdate
        {
            get { return absentdate; }
            set { absentdate = value; }
        }

    }

    public class AbsentCollection:Collection<AbsentInfo>
    {
    }
}
