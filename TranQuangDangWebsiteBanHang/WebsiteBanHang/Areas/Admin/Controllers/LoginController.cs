using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Models;
using WebsiteBanHang.Common;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                var result = dao.login(user.Username, Encryptor.EncryptMD5(user.Password));
                if (result == "")
                {
                    Session.Add(Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result);
                }
            }
            return View("Index");
        }
    }
}