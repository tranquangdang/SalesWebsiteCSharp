using ModelEF.DAO;
using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.EF;
using System.IO;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public List<SelectListItem> getStatusList()
        {
            List<SelectListItem> getStatusList = new List<SelectListItem>();
            getStatusList.Add(new SelectListItem
            {
                Text = "Có sẵn",
                Value = "1"
            });
            getStatusList.Add(new SelectListItem
            {
                Text = "Không có sẵn",
                Value = "0"
            });
            return getStatusList;
        }

        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var model = new ProductDAO().ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string keyword, int page = 1, int pagesize = 10)
        {
            var model = new ProductDAO().ListWhereAll(keyword, page, pagesize);
            ViewBag.SearchString = keyword;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string str)
        {
            var model = new ProductDAO();
            var getCateList = model.getCate();
            
            if (str != null)
            {
                var ProductID = Convert.ToInt32(str);
                var result = model.Find(ProductID);
                ViewBag.CategoryNameList = new SelectList(getCateList, "ID", "Name", result.CategoryNo);
                ViewBag.StatusList = new SelectList(getStatusList(), "Value", "Text", result.Status);
                return View(result);
            }
            else
            {
                ViewBag.Update = true;
                ViewBag.CategoryNameList = new SelectList(getCateList, "ID", "Name");
                ViewBag.StatusList = new SelectList(getStatusList(), "Value", "Text");
                return View();
            }

        }

        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase postedFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    postedFile = Request.Files["Image"];
                    if (postedFile.ContentLength <= 0 && model.ID == 0)
                    {
                        ViewBag.CategoryNameList = new SelectList(new ProductDAO().getCate(), "ID", "Name");
                        SetAlert("Vui lòng chọn ảnh!", "error");
                        return RedirectToAction("Create", "Product");
                    }

                    if (postedFile.ContentLength > 0)
                    {
                        string filePath = "";
                        filePath = Server.MapPath("~/Images/");
                        var fileName = Path.GetFileName(postedFile.FileName);
                        filePath = filePath + fileName;
                        postedFile.SaveAs(filePath);
                        DeleteImg(model.Image);
                        model.Image = "~/Images/" + fileName;
                    }

                    string result = "";
                    result = new ProductDAO().Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        SetAlert("Lỗi", "error");
                    }
                }
                else
                {
                    ViewBag.CategoryNameList = new SelectList(new ProductDAO().getCate(), "ID", "Name");
                    ViewBag.StatusList = new SelectList(getStatusList(), "Value", "Text");
                    SetAlert("Lỗi", "error");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            var model = new ProductDAO();
            DeleteImg(model.Find(ID).Image);
            model.Delete(ID);
            return RedirectToAction("Index");
        }

        public void DeleteImg(string pathName)
        {
            if (!string.IsNullOrEmpty(pathName))
            {
                if (pathName.Substring(0, 4) != "http")
                {
                    string fullPath = Request.MapPath(pathName);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
            }
        }
    }
}