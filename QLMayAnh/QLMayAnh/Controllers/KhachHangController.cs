using PagedList;
using QLMayAnh.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLMayAnh.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        ShopModelsData db = new ShopModelsData();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int page=1, int pagesize=10)
        {
            if (Session["us"] == null) return RedirectToAction("Login", "MayAnh");
            else
            {
                var lst = (db.KHACHHANGs.SqlQuery("select * from KhachHang").ToList<KHACHHANG>()).ToPagedList(page, pagesize);
                return View(lst);
            }
        }

        public ActionResult Create()
        {
            if (Session["us"] == null) return RedirectToAction("Login", "MayAnh");
            else
                return View();
        }

        [HttpPost]
        public ActionResult Create(KHACHHANG pr)
        {
            db.KHACHHANGs.Add(pr);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            if (Session["us"] == null) return RedirectToAction("Login", "MayAnh");
            else
            {
                KHACHHANG pr = new KHACHHANG();
                pr = db.KHACHHANGs.Find(id);
                return View(pr);
            }
        }
        [HttpPost]
        public ActionResult Edit(KHACHHANG pr)
        {
            KHACHHANG kHACHHANG = new KHACHHANG();
            kHACHHANG = db.KHACHHANGs.Find(pr.IDKH);
            if (kHACHHANG != null)
            {
                kHACHHANG.TENKH = pr.TENKH;
                kHACHHANG.SDT = pr.SDT;
                kHACHHANG.DIACHI = pr.DIACHI;
                kHACHHANG.EMAIL = pr.EMAIL;
               
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            if (Session["us"] == null) return RedirectToAction("Login", "MayAnh");
            else
            {
                KHACHHANG pr = new KHACHHANG();
                pr = db.KHACHHANGs.Find(id);
                return View(pr);
            }
        }
        [HttpPost]
        public ActionResult Delete(KHACHHANG pr)
        {
            KHACHHANG kHACHHANG = new KHACHHANG();
            kHACHHANG = db.KHACHHANGs.Find(pr.IDKH);
            if (kHACHHANG != null)
            {
                db.KHACHHANGs.Remove(pr);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}