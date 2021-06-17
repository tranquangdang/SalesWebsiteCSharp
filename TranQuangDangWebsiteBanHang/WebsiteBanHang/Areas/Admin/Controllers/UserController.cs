using ModelEF.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var model = new AdminDAO().ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string keyword, int page = 1, int pagesize = 5)
        {
            var model = new AdminDAO().ListWhereAll(keyword, page, pagesize);
            ViewBag.SearchString = keyword;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            new AdminDAO().Delete(ID);
            return RedirectToAction("Index");
        }
    }
}