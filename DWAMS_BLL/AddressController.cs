using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;
using DWAMS_DAL;

namespace DWAMS_BLL
{
    public class AddressController
    {
        AddressDataController datacontroller;
        private int count;

        public AddressController() 
        {
            datacontroller = new AddressDataController();
        }

        public void InsertController(AddressInfo info)
        {
            datacontroller.Insert(info.Addname, info.Adddesp);
        }

        public void UpdateController(AddressInfo info)
        {
            datacontroller.Update(info.Addid, info.Addname, info.Adddesp);
        }

        public void DeleteController(string addressid)
        {
            datacontroller.Delete(addressid);
        }

        public AddressCollection SelectController()
        {
            AddressCollection collection = new AddressCollection();
            IDataReader reader = datacontroller.SelectList();

            count = 0;

            while (reader.Read())
            {
                AddressInfo info = new AddressInfo();

                info.Addid = Convert.ToString(reader["AddressId"]);
                info.Addname = Convert.ToString(reader["AddressName"]);
                info.Adddesp = Convert.ToString(reader["Desp"]);
                info.No = Convert.ToString(++count);

                collection.Add(info);
            }
            reader.Close();
            return collection;
        }

        public AddressCollection SelectControllerbyAddress(string address)
        {
            AddressCollection collection = new AddressCollection();
            IDataReader reader = datacontroller.SelectList(address);

            count = 0;

            while (reader.Read())
            {
                AddressInfo info = new AddressInfo();

                info.Addid = Convert.ToString(reader["AddressId"]);
                info.Addname = Convert.ToString(reader["AddressName"]);
                info.Adddesp= Convert.ToString(reader["Desp"]);
                info.No = Convert.ToString(++count);

                collection.Add(info);
            }
            reader.Close();
            return collection;
        }

    }

    public class AddressInfo
    {

        private string addid;
        private string addname;
        private string adddesp,
            no;

        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public string Addid
        {
            get { return addid; }
            set { addid = value; }
        }

        public string Addname
        {
            get { return addname; }
            set { addname = value; }
        }

        public string Adddesp
        {
            get { return adddesp; }
            set { adddesp = value; }
        }

}

    public class AddressCollection : Collection<AddressInfo>
    {
       

    }
}
