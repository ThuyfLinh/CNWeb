using PagedList;
using QLMayAnh.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLMayAnh.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHang
        ShopModelsData db = new ShopModelsData();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int page = 1, int pagesize = 10)
        {
            var lst = (db.DONHANGs.SqlQuery("select * from DonHang").ToList<DONHANG>()).ToPagedList(page,pagesize);
            return View(lst);
        }
       
        private IEnumerable<string> GetAllGhiChu()
        {
            return new List<string>
            {
                "Chưa xử lý ",
                "Đang xử lý",
                "Đã xử lý",
            };
        }
        public ActionResult Edit(int id)
        {
            DONHANG pr = new DONHANG();
            pr = db.DONHANGs.Find(id);
            List<KHACHHANG> cateKhachHang = db.KHACHHANGs.ToList();
            SelectList cateListKhachHang = new SelectList(cateKhachHang, "IDKH", "TenKH");
            ViewBag.IDKH = cateListKhachHang;

            ViewBag.GhiChu = GetAllGhiChu();

            return View(pr);
        }
        [HttpPost]
        public ActionResult Edit(DONHANG pr)
        {
            DONHANG dONHANG = new DONHANG();
            dONHANG = db.DONHANGs.Find(pr.IDDONHANG);
            if (dONHANG != null)
            {
                dONHANG.NGAYLAP= pr.NGAYLAP;
                dONHANG.TRANGTHAI = pr.TRANGTHAI;
                dONHANG.IDKH = pr.IDKH;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        
        public ActionResult Details(int id)
        {
            if (Session["username"] == null) return RedirectToAction("List","CTDonHang");
            else
            {
                return RedirectToAction("List", "CTDonHang", new { id = id });
            }
        }
    }
}