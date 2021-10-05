using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageSchedule.Repositorys;

namespace ManageSchedule.Controllers
{
    public class AuthenticationController : Controller
    {
        UserRepository userRepository = new UserRepository();
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var userName = form["username"];
            var password = form["password"];
            bool checkLogin = userRepository.checkLogin(userName, password);
            if (checkLogin)
            {
                var userInformation = userRepository.getInformationByUserName(userName);
                Session.Add("USER", userInformation);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.mess = "Thông tin tài khoản hoặc mật khẩu không chính xác";
                return View("Login");
            }

        }
        public ActionResult Logout()
        {
            Session.Remove("USER");
            return Redirect("/");
        }
    }
}