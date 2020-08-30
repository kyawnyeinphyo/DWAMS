using System;
using System.Collections.Generic;
using System.Text;
using DWAMS_DAL;
using System.Data;

namespace DWAMS_BLL
{
    public class SettingController
    {
        SettingDataController datacontroller;

        public SettingController()
        {
            datacontroller = new SettingDataController();
        }

        public void  UpdateSetting(DateTime dutyintime, DateTime dutyouttime)
        {
            datacontroller.UpdateSetting(dutyintime, dutyouttime);
        }

        public SettingInfo SelectSetting()
        {
            SettingInfo info = new SettingInfo();

            IDataReader reader = datacontroller.SelectSetting();

            while (reader.Read())
            {
                info.Dutyintime = Convert.ToDateTime(reader["DutyInTime"]);
                info.Dutyouttime = Convert.ToDateTime(reader["DutyOutTime"]);
            }
            reader.Close();
            return info;
        }
    }

    public class SettingInfo
    {
        private DateTime dutyintime,
            dutyouttime;

        public DateTime Dutyouttime
        {
            get { return dutyouttime; }
            set { dutyouttime = value; }
        }

        public DateTime Dutyintime
        {
            get { return dutyintime; }
            set { dutyintime = value; }
        }
    }
}
