using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using DWAMS_DAL;

namespace DWAMS_BLL
{
    public class AttendanceSummeryController
    {
        AttendanceSummeryDataController datacontroller;
        private int count;
	   
        public AttendanceSummeryController()
        {
            datacontroller = new AttendanceSummeryDataController();
        }

        public AttendanceSummeryCollection AttendanceSummerySelect(int month, int year)
        {
            AttendanceSummeryCollection collection = new AttendanceSummeryCollection();
            AttendanceSummeryInfo info;
            IDataReader reader = datacontroller.AttendanceSummerySelect(month, year);

            count = 0;

            while (reader.Read())
            {
                info = new AttendanceSummeryInfo();

                info.Staffid = Convert.ToString(reader["Staffid"]);
                info.Staffcode = Convert.ToString(reader["Staffcode"]);
                info.Staffname = Convert.ToString(reader["Staffname"]);
                info.Latedutyin = Convert.ToString(reader["Latedutyin"]);
                info.Earlydutyout = Convert.ToString(reader["Earlydutyout"]);
                info.Presentday = Convert.ToString(reader["Presentday"]);
                info.Absentday = Convert.ToString(reader["Absentday"]);
                info.No = Convert.ToString(++count);

                collection.Add(info);
            }
            reader.Close();

            return collection;
        }  

    }

    public class AttendanceSummeryInfo
    {
        private string staffid,
            staffcode,
            staffname,
            latedutyin,
            earlydutyout,
            presentday,
            absentday,
            no;

        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public string Presentday
        {
            get { return presentday; }
            set { presentday = value; }
        }

        public string Absentday
        {
            get { return absentday; }
            set { absentday = value; }
        }

        public string Earlydutyout
        {
            get { return earlydutyout; }
            set { earlydutyout = value; }
        }

        public string Latedutyin
        {
            get { return latedutyin; }
            set { latedutyin = value; }
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

        public string Staffid
        {
            get { return staffid; }
            set { staffid = value; }
        }

    }

    public class AttendanceSummeryCollection : Collection<AttendanceSummeryInfo>
    {
    }

}
