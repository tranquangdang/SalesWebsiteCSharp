using ModelEF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class AdminDAO
    {
        private WebDbContext db;

        public AdminDAO()
        {
            db = new WebDbContext();
        }

        public string login(string user, string pass)
        {
            var result = db.UserAccounts.Any(x => x.UserName == user);
            if (!result)
            {
                return "Không tìm thấy tài khoản này!";
            }
            else
            {
                var model = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass));
                if (model != null)
                {
                    if (model.Status != "Blocked")
                    {
                        return "";
                    }
                    else
                    {
                        return "Tài khoản bị khóa! ";
                    }
                }
                else
                {
                    return "Sai mật khẩu! ";
                }
            }
        }

        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }

        public IEnumerable<UserAccount> ListWhereAll(string keyword, int page, int pagesize)
        {
            IEnumerable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(s => s.UserName.Contains(keyword));
            }
            return model.OrderBy(s => s.UserName).ToPagedList(page, pagesize);
        }

        public bool Delete(int ID)
        {
            try
            {
                var model = db.UserAccounts.Find(ID);
                db.UserAccounts.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
