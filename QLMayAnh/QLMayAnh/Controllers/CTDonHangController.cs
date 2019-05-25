using PagedList;
using QLMayAnh.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLMayAnh.Controllers
{
    public class CTDonHangController : Controller
    {
        // GET: CTDonHang
        ShopModelsData db = new ShopModelsData();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int page = 1, int pagesize  =10)
        {
            var lst = (db.CTDONHANGs.SqlQuery("select * from CTDONHANG").ToList<CTDONHANG>()).ToPagedList(page,pagesize);
            return View(lst);
        }
        public ActionResult Create()
        {
            List<DONHANG> cateDonHang = db.DONHANGs.ToList();
            SelectList cateListDonHang = new SelectList(cateDonHang, "IDDONHANG","IDDONHANG");
            ViewBag.IDDONHANG = cateListDonHang;

            List<MAYANH> cate = db.MAYANHs.ToList();
            SelectList cateList = new SelectList(cate, "IDMAY", "TENMAY");
            ViewBag.IDMAY = cateList;

            return View();
        }

        [HttpPost]
        public ActionResult Create(CTDONHANG pr)
        {
            db.CTDONHANGs.Add(pr);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Edit(int id)
        {
            CTDONHANG pr = new CTDONHANG();
            pr = db.CTDONHANGs.Find(id);
            List<DONHANG> cateDonHang = db.DONHANGs.ToList();
            SelectList cateListDonHang = new SelectList(cateDonHang, "IDDONHANG", "IDDONHANG");
            ViewBag.IDDONHANG = cateListDonHang;

            List<MAYANH> cate = db.MAYANHs.ToList();
            SelectList cateList = new SelectList(cate, "IDMAY", "TENMAY");
            ViewBag.IDMAY = cateList;
            return View(pr);
        }
        [HttpPost]
        public ActionResult Edit(CTDONHANG pr)
        {
            CTDONHANG cTDONHANG = new CTDONHANG();
            cTDONHANG = db.CTDONHANGs.Find(pr.IDCTDONHANG);
            if (cTDONHANG != null)
            {
                cTDONHANG.IDDONHANG = pr.IDDONHANG;
                cTDONHANG.IDMAY = pr.IDMAY;
                cTDONHANG.DONGIA = pr.DONGIA;
                cTDONHANG.SOLUONG = pr.SOLUONG;
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var pr = db.CTDONHANGs.Find(id);
            return View(pr);
        }
        [HttpPost]
        public ActionResult Delete(CTDONHANG pr)
        {
            CTDONHANG cTDONHANG = new CTDONHANG();
            cTDONHANG = db.CTDONHANGs.Find(pr.IDCTDONHANG);
            if(cTDONHANG != null)
            {
                db.CTDONHANGs.Remove(pr);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}