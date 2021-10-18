using ManageSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageSchedule.Repositorys
{
    public class CategoryRepository
    {
        ManageScheduleDbContext mydb = new ManageScheduleDbContext();
        public List<Category> getAll()
        {
            return mydb.categories.ToList();
        }
    }
}