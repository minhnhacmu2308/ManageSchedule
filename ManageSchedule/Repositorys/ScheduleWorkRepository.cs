using ManageSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageSchedule.Repositorys
{
    public class ScheduleWorkRepository
    {
        ManageScheduleDbContext mydb = new ManageScheduleDbContext();
        public List<ScheduleWork> getAll()
        {
            return mydb.scheduleWorks.OrderByDescending(m => m.id).ToList();
        }
        public void add(string tieude, DateTime ngay, TimeSpan start, TimeSpan endTime,  string mucdich, string diadiem, string ghichu, int mer_id, int user_id)
        {
            string SQL = "INSERT INTO ScheduleWorks(title, start, endTime, date, purpose, address, note, status, Merchant_id, User_id) VALUES(N'" + tieude + "','" + start + "','" + endTime + "','" + ngay + "',N'" + mucdich + "',N'" + diadiem + "',N'" + ghichu + "',1,'" + mer_id + "','" + user_id + "')";
            mydb.Database.ExecuteSqlCommand(SQL);
        }
        public List<ScheduleWork> getListForUser(int id)
        {
            return mydb.scheduleWorks.Where(a => a.User.id == id).OrderByDescending(b => b.id).ToList();
        }
    }
}