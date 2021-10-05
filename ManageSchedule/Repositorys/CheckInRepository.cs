using ManageSchedule.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManageSchedule.Repositorys
{
    public class CheckInRepository
    {
        ManageScheduleDbContext myDb = new ManageScheduleDbContext();

        public List<CheckIn> getListCheckIn()
        {
            return myDb.checkIns.ToList();
        }

        public List<CheckIn> getListChekInForStaff(int id)
        {
            return myDb.checkIns.Where(c => c.User.id == id).ToList();
        }
        public void postCheckIn(CheckIn checkIn)
        {
            string sql = "insert into CheckIns(checkIn,checkOut,date,status,User_id) values(@checkIn,@checkout,@date,@status,@uId)";
            myDb.Database.ExecuteSqlCommand(sql, new SqlParameter("@checkIn", checkIn.checkIn),
                new SqlParameter("@checkout", checkIn.checkOut),
                new SqlParameter("@date", checkIn.date),
                new SqlParameter("@status", 1),
                new SqlParameter("@uId", checkIn.User.id)
            );
        }

        public CheckIn handleCheckIn(int idUser)
        {
            string sql = "select * from dbo.CheckIns  where User_id = @idUser and  CONVERT(varchar, date, 101) = CONVERT(varchar, getdate(), 101)";
            return myDb.Database.SqlQuery<CheckIn>(sql, new SqlParameter("@idUser", idUser)).FirstOrDefault();
        }

        public CheckIn handleCheckOut(TimeSpan hourCheckOut, DateTime date, int id)
        {
            string sql = "select * from dbo.CheckIns  where checkOut = @hourCheckOut and  CONVERT(varchar, date, 101) = CONVERT(varchar, @date, 101) and User_id = @id";
            var checkIn = myDb.Database.SqlQuery<CheckIn>(sql, new SqlParameter("@hourCheckOut", hourCheckOut),
                new SqlParameter("@date", date),
                new SqlParameter("@id", id)).FirstOrDefault();
            return checkIn;
        }

        public void postCheckOut(TimeSpan timeCheckout, int idUser)
        {
            string sql = "update dbo.CheckIns set checkOut = @timeCheckOut where User_id = @idUser";
            myDb.Database.ExecuteSqlCommand(sql, new SqlParameter("@idUser", idUser), new SqlParameter("@timeCheckOut", timeCheckout));
        }
    }
}