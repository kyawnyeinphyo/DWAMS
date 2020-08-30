using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DWAMS_DAL;
using System.Data;

namespace DWAMS_BLL
{
   public class PositionController
    {
       PositionDataController datacontroller;
       PositionCollection collection;
       IDataReader reader;
       private int count;

        public PositionController() 
        {
            datacontroller = new PositionDataController();
        }

        public void InsertController(PositionInfo info)
        {
            datacontroller.Insert(info.Departmentid, info.Position, info.Positiondesp);
        }

        public void UpdateController(PositionInfo info)
        {
            datacontroller.Update(info.PositionID, info.Departmentid, info.Position, info.Positiondesp);
        }

        public void DeleteController(string positionid)
        {
            datacontroller.Delete(positionid);
        }

       public PositionCollection SelectController(string departmentid)
       {
           collection = new PositionCollection();
           reader = datacontroller.SelectList(departmentid);

           while (reader.Read())
           {
               PositionInfo info = new PositionInfo();

               info.PositionID = Convert.ToString(reader["PositionId"]);
               info.Position = Convert.ToString(reader["Position"]);

               collection.Add(info);
           }
           reader.Close();
           return collection;
       }

       public PositionCollection SelectControllerbyDepartment(string depId)
        {
            collection = new PositionCollection();
            reader = datacontroller.SelectPositionbyDepartment(depId);

            count = 0;

            while (reader.Read())
            {
                PositionInfo info = new PositionInfo();

                info.PositionID = Convert.ToString(reader["PositionId"]);
                info.Departmentid = Convert.ToString(reader["depid"]);
                info.Department = Convert.ToString(reader["depname"]);
                info.Position = Convert.ToString(reader["Position"]);
                info.Positiondesp= Convert.ToString(reader["Desp"]);
                info.No = Convert.ToString(++count);

                collection.Add(info);
            }
            reader.Close();
            return collection;
        }

        public PositionCollection SelectController()
        {
            collection = new PositionCollection();
            reader = datacontroller.SelectList();

            count = 0;

            while (reader.Read())
            {
                PositionInfo info = new PositionInfo();

                info.PositionID = Convert.ToString(reader["PositionId"]);
                info.Departmentid = Convert.ToString(reader["depid"]);
                info.Department = Convert.ToString(reader["depname"]);
                info.Position = Convert.ToString(reader["Position"]);
                info.Positiondesp= Convert.ToString(reader["Desp"]);
                info.No = Convert.ToString(++count);

                collection.Add(info);
            }
            reader.Close();
            return collection;
        }

    }

    public class PositionInfo
    {
        private string positionID;
        private string departmentid,
            department;
        private string position;
        private string positiondesp,
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

        public string Departmentid
        {
            get { return departmentid; }
            set { departmentid = value; }
        }

        public string PositionID
        {
            get { return positionID; }
            set { positionID = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Positiondesp
        {
            get { return positiondesp; }
            set { positiondesp = value; }
        }

    }

    public class PositionCollection:Collection<PositionInfo>
    {
    }
}
