using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteBanHang.Areas.Website.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Website/Home
        public ActionResult Index()
        {
            InitViewBag();
            return View();
        }
    }
}