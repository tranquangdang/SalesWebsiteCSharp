using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebsiteBanHang.Areas.Website.Controllers
{
    public class BaseController : Controller
    {
        public void InitViewBag()
        {
            var cate = new ProductDAO().getCate();
            ViewBag.Category = cate;
        }
    }
}