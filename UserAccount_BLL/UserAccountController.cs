using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using UserAccount_DAL;

namespace UserAccount_BLL
{
    public class UserAccountController
    {
        UserAccountDataAccess dataAccess;

        public enum SelectType
        {
            ActiveTrueAdmin, ActiveTrue, Active_False,NotExist
        }

        public UserAccountController()
        {
            dataAccess = new UserAccountDataAccess();
        }

        public void InsertController(UserAccountInfo info)
        {
            dataAccess.AddNewAccount(info.Username, info.Password, info.Permission);
        }

        public void UpdateController(UserAccountInfo info)
        {
            dataAccess.UpdateAccount(info.Username, info.Password);
        }

        public void DeleteController(UserAccountInfo info)
        {
            dataAccess.DeleteUserAccount(info.Userid);
        }

        public SelectType SelectController(UserAccountInfo info)
        {
            IDataReader reader = dataAccess.RetriveUserAccount(info.Username, info.Password);

            if (reader.Read())
            {
                if ((Convert.ToString(reader["Active"]).Equals("yes")) && (Convert.ToString(reader["Permission"]).Equals("yes")))
                {
                    return SelectType.ActiveTrueAdmin;
                }
                else if (Convert.ToString(reader["Active"]).Equals("yes"))
                {
                    return SelectType.ActiveTrue;
                }
                else
                {
                    return SelectType.Active_False;
                }
            }
            else
            {
                return SelectType.NotExist;
            }
            
        }

        public UserAccountCollection SelectUserListController()
        {
            UserAccountCollection collection = new UserAccountCollection();
            IDataReader reader = dataAccess.SelectUserList();

            int count = 0;

            while (reader.Read())
            {
                UserAccountInfo info = new UserAccountInfo();
                
                info.Userid = Convert.ToString(reader["UserId"]);
                info.Username = Convert.ToString(reader["UserName"]);
                info.Password = Convert.ToString(reader["Password"]);
                info.Active = Convert.ToString(reader["Active"]);
                info.Permission = Convert.ToString(reader["Permission"]);
                info.No = Convert.ToString(++count);
                
                collection.Add(info);
            }
            reader.Close();
            return collection;
        }

        public bool SelectUserListbyName(string username)
        {
            UserAccountCollection collection = new UserAccountCollection();
            IDataReader reader = dataAccess.SelectUserListbyName(username);

            if (reader.Read())
            {
                return true;
            }
            reader.Close();
            return false;  
        }

        public int SelectPermissionAccount()
        {
            IDataReader reader = dataAccess.SelectPermissionAccount();

            int num = 0;

            if (reader.Read())
            {
                num = Convert.ToInt32(reader["Number"]);
            }
            reader.Close();
            return num;
        }
    }

    public class UserAccountInfo
    {
        private string userid, username, password, permission, active, no;

        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public string Active
        {
            get { return active; }
            set { active = value; }
        }

        public string Permission
        {
            get { return permission; }
            set { permission = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }


    }

    public class UserAccountCollection : Collection<UserAccountInfo>
    {

    }
}
