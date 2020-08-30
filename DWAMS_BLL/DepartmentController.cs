using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DWAMS_DAL;
using System.Data;

namespace DWAMS_BLL
{
  public  class DepartmentController
    {
      DepartmentDataController datacontroller;
      private int count;
	  
      public DepartmentController()
      {
          datacontroller = new DepartmentDataController(); 
      }

      public void InsertController(DepartmentInfo info)
      {
          datacontroller.Insert(info.Depname, info.Depdesp);
      }

      public void UpdateController(DepartmentInfo info)
      {
          datacontroller.Update(info.DepId, info.Depname, info.Depdesp);
      }

      public void DeleteController(string depid)
      {
          datacontroller.Delete(depid);
      }

      public DepartmentCollection SelectControllerbyDepartment(string department)
      {
          DepartmentCollection collection = new DepartmentCollection();
          IDataReader reader = datacontroller.SelectList(department);
          count = 0;
          while (reader.Read())
          {
              DepartmentInfo info = new DepartmentInfo();

              info.DepId = Convert.ToString(reader["DepId"]);
              info.Depname = Convert.ToString(reader["DepName"]);
              info.Depdesp = Convert.ToString(reader["Desp"]);
              info.No = Convert.ToString(++count);

              collection.Add(info);
          }
          reader.Close();
          return collection;
      }

      public DepartmentCollection SelectController()
      {
          DepartmentCollection collection = new DepartmentCollection();
          IDataReader reader = datacontroller.SelectList();
          count = 0;
          while (reader.Read())
          {
              DepartmentInfo info = new DepartmentInfo();

              info.DepId = Convert.ToString(reader["DepId"]);
              info.Depname = Convert.ToString(reader["DepName"]);
              info.Depdesp = Convert.ToString(reader["Desp"]);
              info.No = Convert.ToString(++count);
              collection.Add(info);
          }
          reader.Close();
          return collection;
      }
    }

    public class DepartmentInfo
    {
        private string depId;
        private string depname;
        private string depdesp,
            no;

        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public string DepId
        {
            get { return depId; }
            set { depId = value; }
        }

        public string Depname
        {
            get { return depname; }
            set { depname = value; }
        }

        public string Depdesp
        {
            get { return depdesp; }
            set { depdesp = value; }
        }
    }

    public class DepartmentCollection:Collection<DepartmentInfo>
    {
    }
}
