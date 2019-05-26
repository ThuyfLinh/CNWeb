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

        public ActionResult SearchG(int giadau, int giacuoi)
        {
            List<MAYANH> lst = db.Database.SqlQuery<MAYANH>("SearchPrice @giadau , @giacuoi", new SqlParameter("giadau ", giadau), new SqlParameter("giacuoi ", giacuoi)).ToList();
            return View("Index", lst);
        }
        public ActionResult SearchTL(string tenlmay)
        {
            List<MAYANH> lst = db.Database.SqlQuery<MAYANH>("SearchTL @tenlmay", new SqlParameter("tenlmay", tenlmay)).ToList();
            return View("Index", lst);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Single(int? id)
        {
            var sp = db.MAYANHs.Where(x => x.IDMAY == id).ToList();
            if (sp != null)
            {
                return View(sp);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Payment()
        {

            return View();
        }

        [HttpPost]
        public ActionResult InsertData()
        {
            string name = Request.Form["billing_last_name"];
            string street = Request.Form["billing_address_1"];
            string apartment = Request.Form["billing_address_2"];
            string city = Request.Form["billing_city"];
            string email = Request.Form["billing_email"];
            int phone = Int32.Parse(Request.Form["billing_phone"]);
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            List<Item> lst = new List<Item>();
            if (cart != null)
            {

                lst = cart.lst;
                if (db.KHACHHANGs.Where(q => q.TENKH == name && q.SDT == phone && q.EMAIL == email).FirstOrDefault() == null)
                {
                    KHACHHANG khachhang = new KHACHHANG();
                    khachhang.TENKH = name;
                    khachhang.DIACHI = street + " - " + apartment + " - " + city;
                    khachhang.EMAIL = email;
                    khachhang.SDT = phone;
                    db.KHACHHANGs.Add(khachhang);
                    db.SaveChanges();
                }

                DONHANG donHang = new DONHANG();
                var x = db.KHACHHANGs.Where(q => q.TENKH == name && q.SDT == phone && q.EMAIL == email).FirstOrDefault();
                donHang.IDKH = x.IDKH;
                donHang.NGAYLAP = DateTime.Today;
                donHang.TRANGTHAI = "chưa được xử lý";
                db.DONHANGs.Add(donHang);
                db.SaveChanges();

                //               var y = db.DonHangs.Where(q => q.IDKH == x.IDKH && q.NgayLap == DateTime.Today && q.TrangThai == "Chua du?c x? lý").FirstOrDefault();

                foreach (var item in lst)
                {
                    CTDONHANG cTDonHang = new CTDONHANG();

                    cTDonHang.IDDONHANG = donHang.IDDONHANG;
                    cTDonHang.IDMAY = item.id;
                    cTDonHang.SOLUONG = item.amount;
                    cTDonHang.DONGIA = (int)item.price;
                    db.CTDONHANGs.Add(cTDonHang);
                    db.SaveChanges();
                }
                cart.lst = null;
            }
            return RedirectToAction("Index");
        }
    }
}