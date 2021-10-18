using ManageSchedule.Models;
using ManageSchedule.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageSchedule.Controllers
{
    public class ScheduleWorkController : Controller
    {
        // GET: ScheduleWork
        ScheduleWorkRepository mer = new ScheduleWorkRepository();
        MerchantRepository mch = new MerchantRepository();
        public ActionResult Index(string mess)
        {
            var user = (User)Session["USER"];
            ViewBag.List = null;
            if (user.Role.id == 1)
            {
                ViewBag.List = mer.getAll();
            }
            else
            {
                ViewBag.List = mer.getListForUser(user.id);
            }
            ViewBag.Msg = mess;
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddNew(FormCollection form)
        {
            var user = (User)Session["USER"];
            var tieude = form["tieude"];
            var date = form["date"];
            var start = form["start"];
            var end = form["end"];
            var mucdich = form["mucdich"];
            var ghichu = form["ghichu"];
            TimeSpan batdau = TimeSpan.Parse(start);
            TimeSpan ketthuc = TimeSpan.Parse(end);
            DateTime ngay = DateTime.Parse(date);
            var merchant = Int32.Parse(form["merchant"]);
            var diadiem = mch.getMerchant(merchant).headquarter;
            mer.add(tieude,ngay,batdau,ketthuc,mucdich,diadiem,ghichu,merchant,user.id);
            var message = "1";
            return RedirectToAction("Index", new { mess = message });
        }
    }
}