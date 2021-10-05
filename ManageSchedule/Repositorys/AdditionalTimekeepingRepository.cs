using ManageSchedule.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManageSchedule.Repositorys
{
    public class AdditionalTimekeepingRepository
    {
        ManageScheduleDbContext myDb = new ManageScheduleDbContext();
        public void add(AdditionalTimekeeping additionalTimekeeping)
        {
            string sql = "insert into AdditionalTimekeepings(type,typeChild,start,endTime,date,note,status,User_id,created) values(@type,@typeC,@start,@end,@date,@note,@status,@User_id,@created)";
            myDb.Database.ExecuteSqlCommand(sql, 
                new SqlParameter("@type",additionalTimekeeping.type),
                new SqlParameter("@typeC", additionalTimekeeping.typeChild),
                new SqlParameter("@start", additionalTimekeeping.start),
                new SqlParameter("@end", additionalTimekeeping.endTime),
                new SqlParameter("@date", additionalTimekeeping.date),
                new SqlParameter("@note", additionalTimekeeping.note),
                new SqlParameter("@status", additionalTimekeeping.status),
                new SqlParameter("@User_id", additionalTimekeeping.User.id),
                 new SqlParameter("@created", additionalTimekeeping.created)
                );

        }

        public List<AdditionalTimekeeping> getListForAdmin()
        {
            return myDb.additionalTimekeepings.ToList();
        }

        public List<AdditionalTimekeeping> getListForUser(int id)
        {
            return myDb.additionalTimekeepings.Where(a => a.User.id == id).ToList();
        }

        public AdditionalTimekeeping getAdditionalTimekeeping(int id)
        {
            return myDb.additionalTimekeepings.Where(a => a.id == id).FirstOrDefault();
        }
        public void updateStatus(int status, int id)
        {
            var obj = getAdditionalTimekeeping(id);
            obj.status = status;
            myDb.SaveChanges();
        }
    }
}