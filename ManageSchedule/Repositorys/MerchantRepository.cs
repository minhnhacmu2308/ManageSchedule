using ManageSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageSchedule.Repositorys
{
    public class MerchantRepository
    {
        ManageScheduleDbContext mydb = new ManageScheduleDbContext();
        public List<Merchant> getAll()
        {
            return mydb.merchants.OrderByDescending(m => m.id).ToList();
        }
        public void add(string name, string phone, string email, string tch, string theloai, string dichvu, int cate_id, string truso,int user_id, DateTime now)
        {
            string SQL = "INSERT INTO Merchants(fullName, phoneNumber, email, nameStore, typeMerchant, service, headquarter, status, Category_id, User_id, created) VALUES(N'" + name + "','" + phone + "',N'" + email + "',N'" + tch + "',N'" + theloai + "',N'" + dichvu + "',N'" + truso + "',1,'" + cate_id + "','"+user_id+"', '" + now + "')";
            mydb.Database.ExecuteSqlCommand(SQL);
        }
        public List<Merchant> getListForUser(int id)
        {
            return mydb.merchants.Where(a => a.User.id == id).OrderByDescending(b => b.id).ToList();
        }
        public Merchant getMerchant(int id)
        {
            return mydb.merchants.Where(m => m.id == id).FirstOrDefault();
        }
    }
}