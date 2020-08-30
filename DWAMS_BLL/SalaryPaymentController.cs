using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DWAMS_DAL;
using System.Data;

namespace DWAMS_BLL
{
    public class SalaryPaymentController
    {
        SalaryPaymentDataController datacontroller;
        private int count;
	   
        public SalaryPaymentController()
        {
            datacontroller = new SalaryPaymentDataController();
        }


        public SalaryPaymentCollection SelectMonthlyPayment(int month, int year)
        {
            IDataReader reader = datacontroller.SelectMonthlyPayment(month, year);
            SalaryPaymentCollection collection = new SalaryPaymentCollection();
            SalaryPaymentInfo info;

            count = 0;

            while (reader.Read())
            {
                info = new SalaryPaymentInfo();

                info.Paymentid = Convert.ToString(reader["PaymentId"]);
                info.Staffid = Convert.ToString(reader["StaffId"]);
                info.Staffcode = Convert.ToString(reader["Staffcode"]);
                info.Staffname = Convert.ToString(reader["Staffname"]);
                info.Monthdate = Convert.ToDateTime(reader["Monthdate"]);
                info.Paymentdate = Convert.ToDateTime(reader["Paymentdate"]);
                info.Basicsalary = Convert.ToDouble(reader["Basicsalary"]);
                info.Fine = Convert.ToDouble(reader["Fine"]);
                info.Bonus = Convert.ToDouble(reader["Bonus"]);
                info.Netsalary = Convert.ToDouble(reader["Netsalary"]);
                info.No = Convert.ToString(++count);

                collection.Add(info);
            }
            reader.Close();

            return collection;
        }

        public void InsertMonthlyPayment(string staffid, DateTime paymentdate, DateTime monthdate, double fine, double bonus, double netsalary)
        {
            datacontroller.InsertMonthlyPayment(staffid, paymentdate, monthdate, fine, bonus, netsalary);
        }

    }

    public class SalaryPaymentInfo
    {
        private string staffid,
            paymentid,
            staffcode,
            staffname,
            no;

        public string No
        {
            get { return no; }
            set { no = value; }
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

        public string Paymentid
        {
            get { return paymentid; }
            set { paymentid = value; }
        }

        public string Staffid
        {
            get { return staffid; }
            set { staffid = value; }
        }

        private DateTime monthdate,
            paymentdate;

        public DateTime Paymentdate
        {
            get { return paymentdate; }
            set { paymentdate = value; }
        }

        public DateTime Monthdate
        {
            get { return monthdate; }
            set { monthdate = value; }
        }

        private double basicsalary,
            fine,
            bonus,
            netsalary;

        public double Netsalary
        {
            get { return netsalary; }
            set { netsalary = value; }
        }

        public double Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public double Fine
        {
            get { return fine; }
            set { fine = value; }
        }

        public double Basicsalary
        {
            get { return basicsalary; }
            set { basicsalary = value; }
        }
    }

    public class SalaryPaymentCollection : Collection<SalaryPaymentInfo>
    {

    }
}
