using ModelEF.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteBanHang.Areas.Website.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController() {
            InitViewBag();
        }

        [HttpGet]
        public ActionResult List(int CategoryID, int page = 1, int pagesize = 12)
        {
            var model = new ProductDAO();
            ViewBag.CategoryID = CategoryID;
            var result = model.ListAll();
            if (CategoryID > 0)
            {
                result = model.ListByCategoryID(CategoryID);
            }
            return View(result.ToPagedList(page, pagesize));
        }


        [HttpGet]
        public ActionResult Detail(int id)
        {
            return View(new ProductDAO().Find(id));
        }
    }
}