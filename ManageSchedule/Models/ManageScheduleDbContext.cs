using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ManageSchedule.Models
{
    public class ManageScheduleDbContext : DbContext
    {
        public ManageScheduleDbContext(): base("QuanLiChamCongConectionString")
        {

        }
        public DbSet<User> users { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Merchant> merchants { get; set; }

        public DbSet<AdditionalTimekeeping> additionalTimekeepings { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<CheckIn> checkIns { get; set; }

        public DbSet<ScheduleWork> scheduleWorks { get; set; }

    }
}