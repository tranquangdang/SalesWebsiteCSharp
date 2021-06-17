using ModelEF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDAO
    {
        private WebDbContext db;

        public ProductDAO()
        {
            db = new WebDbContext();
        }

        public List<Product> ListAll()
        {
            return db.Products.OrderBy(p => p.Quantity).ThenByDescending(p => p.UnitCost).ToList();
        }

        public List<Product> ListByCategoryID(int id)
        {
            return db.Products.Where(p => p.CategoryNo == id).ToList();
        }

        public Product Find(int ProductID)
        {
            return db.Products.Find(ProductID);
        }

        public string Insert(Product productEntity)
        {
            var product = Find(productEntity.ID);
            if (product == null)
            {
                db.Products.Add(productEntity);
            }
            else
            {
                product.CategoryNo = productEntity.CategoryNo;
                product.Name = productEntity.Name;
                product.UnitCost = productEntity.UnitCost;
                product.Quantity = productEntity.Quantity;
                product.Image = productEntity.Image;
                product.Description = productEntity.Description;
                product.Status = productEntity.Status;
            }
            db.SaveChanges();
            return productEntity.ID.ToString();
        }

        public bool Delete(int ProductID)
        {
            try
            {
                var product = Find(ProductID);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Category> getCate()
        {
            return db.Categories.ToList();
        }

        public IEnumerable<Product> ListWhereAll(string keyword, int page, int pagesize)
        {
            IEnumerable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(s => s.Name.Contains(keyword));
            }
            return model.OrderBy(s => s.Name).ToPagedList(page, pagesize);
        }
    }
}
