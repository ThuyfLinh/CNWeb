using QLMayAnh.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLMayAnh.Controllers
{
    public class BanHangController : Controller
    {
        ShopModelsData db = new ShopModelsData();
        // GET: BanHang
        public ActionResult Index()
        {
            var lst = db.MAYANHs.ToList();
            return View(lst);
        }
        public ActionResult Product()
        {
            var lst = db.MAYANHs.ToList();
            return View(lst);
        }
        public ActionResult Right()
        {
            return PartialView("~/Views/Shared/Right.cshtml");
        }

        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string Ten)
        {
            var lst = db.Database.SqlQuery<MAYANH>("SearchSP @tenmay", new SqlParameter("tenmay", Ten)).ToList();
            return View("Index", lst);
        }
        
        public ActionResult SearchG(int giadau , int giacuoi)
        {
            List<MAYANH> lst = db.Database.SqlQuery<MAYANH>("SearchPrice @giadau , @giacuoi", new SqlParameter("giadau ", giadau), new SqlParameter("giacuoi ", giacuoi)).ToList();
            return View("Index" ,lst);
        }
        public ActionResult About()
        {
            return View();
        }
        
    }
}