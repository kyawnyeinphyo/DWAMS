using System;
using System.Collections.Generic;
using System.Text;
using DWAMS_DAL;
using System.Collections.ObjectModel;
using System.Data;

namespace DWAMS_BLL
{
    public class UnPaidListController
    {
        UnPaidListDataAccess dataAccess;
        private int count;
	   
        //private DateTime DUTY_IN_TIME;
        //private DateTime DUTY_OUT_TIME;

        IDataReader reader;
        UnPaidListCollection collection;
        UnPaidListInfo info;


        public UnPaidListController()
        {
            dataAccess = new UnPaidListDataAccess();
        }

        public UnPaidListInfo SelectDutyInformation(string staffid, DateTime pay_date, int month, int year)
        {
            reader = dataAccess.Select_total_late_early(staffid, pay_date, month, year);

            info = new UnPaidListInfo();
            while (reader.Read())
            {
                if (string.IsNullOrEmpty(Convert.ToString(reader["TotalLate"])))
                {
                    info.Totallatedutyin = 0;
                }
                else
                {
                    info.Totallatedutyin = Convert.ToInt32(reader["TotalLate"]);
                }

                if (string.IsNullOrEmpty(Convert.ToString(reader["TotalEarly"])))
                {
                    info.Totalearlydutyout = 0;
                }
                else
                {
                    info.Totalearlydutyout = Convert.ToInt32(reader["TotalEarly"]);
                }
               

            }
            reader.Close();

            reader = dataAccess.Select_total_absent(staffid, month, year);
            while (reader.Read())
            {
                info.Totalabsent = Convert.ToInt32(reader["TotalAbsent"]);
            }
            reader.Close();

            reader = dataAccess.Select_total_present(staffid, month, year);
            while (reader.Read())
            {
                info.Totalpresent = Convert.ToInt32(reader["TotalPresent"]);
            }
            reader.Close();

            return info;
        }

        public UnPaidListCollection SelectUnPaidList(int pay_for_month, int pay_for_year)
        {
            reader = dataAccess.SelectUnPaidList(pay_for_month, pay_for_year);
            collection = new UnPaidListCollection();

            Operation();

            return collection;
        }

        public UnPaidListCollection SelectUnPaidList(string departmentid, int pay_for_month, int pay_for_year)
        {
            reader = dataAccess.SelectUnPaidList(departmentid, pay_for_month, pay_for_year);
            collection = new UnPaidListCollection();

            Operation();

            return collection;
        }

        private void Operation()
        {
            count = 0;
            while (reader.Read())
            {
                info = new UnPaidListInfo();

                info.Staffid = Convert.ToString(reader["Staffid"]);
                info.Staffcode = Convert.ToString(reader["Staffcode"]);
                info.Staffname = Convert.ToString(reader["Staffname"]);
                info.Position = Convert.ToString(reader["Position"]);
                info.Department = Convert.ToString(reader["Department"]);
                info.Basicsalary = Convert.ToInt32(reader["Basicsalary"]);
                info.No = Convert.ToString(++count);

                collection.Add(info);
            }
            reader.Close();
        }

        public void UpdatePaidStatus(string staffid, int month, int year)
        {
            dataAccess.UpdatePaidStatus(staffid, month, year);
            dataAccess.UpdateAbsentPaidStatus(staffid, month, year);
        }


        public bool CheckPaid(string staffid, int day, int month, int year)
        {
            reader = dataAccess.CheckPaid(staffid, day, month, year);

            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
 
    }

    public class UnPaidListInfo
    {
        private string 
            staffid,
            staffcode,
            staffname,
            department,
            position,
            no;

        private int 
            basicsalary,
            totallatedutyin,
            totalearlydutyout,
            totalpresent,
            totalabsent;

        public int Totalabsent
        {
            get { return totalabsent; }
            set { totalabsent = value; }
        }

        public int Totalpresent
        {
            get { return totalpresent; }
            set { totalpresent = value; }
        }


        public string No
        {
            get { return no; }
            set { no = value; }
        }


        public int Totalearlydutyout
        {
            get { return totalearlydutyout; }
            set { totalearlydutyout = value; }
        }

        public int Totallatedutyin
        {
            get { return totallatedutyin; }
            set { totallatedutyin = value; }
        }

        public int Basicsalary
        {
            get { return basicsalary; }
            set { basicsalary = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
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

    public class UnPaidListCollection : Collection<UnPaidListInfo>
    {
    }
}
