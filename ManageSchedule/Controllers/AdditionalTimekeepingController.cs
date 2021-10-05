using ManageSchedule.Models;
using ManageSchedule.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageSchedule.Controllers
{
    public class AdditionalTimekeepingController : Controller
    {
        AdditionalTimekeepingRepository AdditionalTimekeepingRepository = new AdditionalTimekeepingRepository();
        // GET: AdditionalTimekeeping
        public ActionResult Index(string mess)
        {
            var user = (User)Session["USER"];
            List<AdditionalTimekeeping> list = null;
            if (user.Role.id == 1)
            {
                list = AdditionalTimekeepingRepository.getListForAdmin();
            }
            else
            {
                list = AdditionalTimekeepingRepository.getListForUser(user.id);
            }
            ViewBag.Msg = mess;
            return View(list);
        }

        public ActionResult Add(string mess)
        {
            ViewBag.Msg = mess;
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            var user = (User)Session["USER"];
            var kieu = form["kieu"];
            var loai = form["theloai"];
            var ngay = form["date"];
            var start = form["start"];
            var end = form["end"];
            var note = form["note"];
            DateTime aDateTime = DateTime.Now;
            AdditionalTimekeeping additional = new AdditionalTimekeeping();
            additional.type = kieu;
            additional.typeChild = loai;
            additional.start = TimeSpan.Parse(start);
            additional.endTime = TimeSpan.Parse(end);
            additional.date = DateTime.Parse(ngay);
            additional.note = note;
            additional.status = 0;
            additional.User = user;
            additional.created = aDateTime;
            AdditionalTimekeepingRepository.add(additional);
            return RedirectToAction("Add",new { mess = "1"});
        }

        public ActionResult changeStatus(int id, int status)
        {
            AdditionalTimekeepingRepository.updateStatus(status, id);
            return RedirectToAction("Index", new { mess = "1" });
        }
    }
}