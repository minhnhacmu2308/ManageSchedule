using ManageSchedule.Models;
using ManageSchedule.Repositorys;
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
        CheckInRepository checkInRepository = new CheckInRepository();
      
        // GET: CheckIn
        public ActionResult Index(string mess)
        {
            var user = (User)Session["USER"];
            CheckIn obj = null;
            CheckIn objC = null;
            if (user != null)
            {
                DateTime aDateTime = DateTime.Now;
                TimeSpan timeOfDay = aDateTime.TimeOfDay;
                TimeSpan interval = new TimeSpan(0, 0, 00);
                obj = checkInRepository.handleCheckIn(user.id);
                objC = checkInRepository.handleCheckOut(interval,aDateTime,user.id);
                ViewBag.check = obj;
                ViewBag.checkDone = objC;
                ViewBag.Msg = mess;

                List<CheckIn> list = null;
                if(user.Role.id == 1)
                {
                    list = checkInRepository.getListCheckIn();
                }
                else
                {
                    list = checkInRepository.getListChekInForStaff(user.id);
                }
               
                return View(list);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
           
        }
        public ActionResult Test()
        {
            ViewBag.L = mydb.roles.Where(c => c.id == 1).FirstOrDefault();
            return View();
        }
        public ActionResult A()
        {
            ViewBag.L = mydb.roles.Where(c => c.id == 1).FirstOrDefault();
            return View();
        }

        public ActionResult checkIn()
        {
            var user = (User)Session["USER"];
            DateTime aDateTime = DateTime.Now;
            TimeSpan timeOfDay = aDateTime.TimeOfDay;
            TimeSpan interval = new TimeSpan(0, 0, 00);
            CheckIn checkin = new CheckIn();
            checkin.checkIn = timeOfDay;
            checkin.checkOut = interval;
            checkin.date = aDateTime;
            checkin.User = user;
            checkInRepository.postCheckIn(checkin);
            return RedirectToAction("Index", new { mess = "1" });
        }
        public ActionResult checkOut()
        {
            var user = (User)Session["USER"];
            DateTime aDateTime = DateTime.Now;
            TimeSpan timeOfDay = aDateTime.TimeOfDay;
            checkInRepository.postCheckOut(timeOfDay, user.id);
            return RedirectToAction("Index", new { mess = "1"});
        }
    }
}