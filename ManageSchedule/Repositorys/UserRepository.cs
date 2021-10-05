using ManageSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ManageSchedule.Repositorys
{
    public class UserRepository
    {
        ManageScheduleDbContext myDb = new ManageScheduleDbContext();

        public bool checkLogin(string userName, string password)
        {
            var user = myDb.users.Where(u => u.userName == userName && u.password == password).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User getInformationByUserName(string username)
        {
            return myDb.users.Where(u => u.userName == username).FirstOrDefault();
        }

       
    }
}