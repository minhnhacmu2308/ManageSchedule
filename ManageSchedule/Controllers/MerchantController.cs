﻿using ManageSchedule.Models;
using ManageSchedule.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageSchedule.Controllers
{
    public class MerchantController : Controller
    {
        MerchantRepository mer = new MerchantRepository();
        // GET: Merchant
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
            var user_id = user.id;
            var fullname = form["hoten"];
            var phone = form["sdt"];
            var email = form["email"];
            var tch = form["tench"];
            var theloai = form["loaimerchant"];
            var dichvu = form["dichvu"];
            DateTime now = DateTime.Now;
            var nganhhang = Int32.Parse(form["nganhhang"]);
            var truso = form["truso"];
            mer.add(fullname, phone, email, tch, theloai, dichvu, nganhhang, truso,user_id, now);
            var message = "1";
            return RedirectToAction("Index", new { mess = message });
        }
    }
}