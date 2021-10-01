using ManageSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageSchedule.Controllers
{
  
    public class CheckInController : Controller
    {
        ManageScheduleDbContext mydb = new ManageScheduleDbContext();
        // GET: CheckIn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            ViewBag.L = mydb.roles.Where(c => c.id==1).FirstOrDefault();
            return View();
        }
    }
}