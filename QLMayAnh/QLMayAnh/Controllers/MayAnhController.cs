using PagedList;
using QLMayAnh.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLMayAnh.Controllers
{
    public class MayAnhController : Controller
    {
        // GET: MayAnh
        ShopModelsData db = new ShopModelsData();
        public ActionResult Index()
        {
            var lst = db.Database.SqlQuery<MAYANH>("Select * From MAYANH ").ToList<MAYANH>();
            return View(lst.ToList());
        }
        public ActionResult List(int page = 1, int pagesize=10)
        {
            List<LOAIMAY> cateLoaiMay = db.LOAIMAYs.ToList();
            ViewBag.IDLOAIMAY = cateLoaiMay;

            var lst = (db.MAYANHs.SqlQuery("select * from MayAnh").ToList<MAYANH>()).ToPagedList(page, pagesize);
            return View(lst);
        }
        public ActionResult Create()
        {
            List<LOAIMAY> cateLoaiMay = db.LOAIMAYs.ToList();
            SelectList cateListLoaiMay = new SelectList(cateLoaiMay, "IDLOAIMAY", "TENLMAY");
            ViewBag.IDLOAIMAY = cateListLoaiMay;

            return View();
        }

        [HttpPost]
        public ActionResult Create(MAYANH pr, HttpPostedFileBase hinhMinhHoa)
        {
            if(hinhMinhHoa != null && hinhMinhHoa.ContentLength > 0)
            {
                var TenAnh = Path.GetFileName(hinhMinhHoa.FileName);
                var DuongDan = Path.Combine(Server.MapPath("~/Content/images/"), TenAnh);
                pr.HINHANH = TenAnh;
                hinhMinhHoa.SaveAs(DuongDan);
            }
            db.MAYANHs.Add(pr);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Edit(int id)
        {
            MAYANH pr = new MAYANH();
            pr = db.MAYANHs.Find(id);

            List<LOAIMAY> cateLoaiMay = db.LOAIMAYs.ToList();
            SelectList cateListLoaiMay = new SelectList(cateLoaiMay, "IDLOAIMAY", "TENLMAY");
            ViewBag.IDLOAIMAY = cateListLoaiMay;

            return View(pr);
        }
        [HttpPost]
        public ActionResult Edit(MAYANH pr, HttpPostedFileBase hinhMinhHoa)
        {
            
            MAYANH mAYANH = new MAYANH();
            mAYANH = db.MAYANHs.Find(pr.IDMAY);
            if (mAYANH != null)
            {
                if(hinhMinhHoa != null && hinhMinhHoa.ContentLength > 0)
                {
                    var TenAnh = Path.GetFileName(hinhMinhHoa.FileName);
                    var DuongDan = Path.Combine(Server.MapPath("~/Content/images/"), TenAnh);
                    mAYANH.HINHANH = TenAnh;
                    hinhMinhHoa.SaveAs(DuongDan);
                }
                mAYANH.TENMAY = pr.TENMAY;
                mAYANH.MOTA = pr.MOTA;
                mAYANH.DONGIA = pr.DONGIA;
                mAYANH.IDLOAIMAY = pr.IDLOAIMAY;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            MAYANH pr = new MAYANH();
            pr = db.MAYANHs.Find(id);
            return View(pr);
        }
        [HttpPost]
        public ActionResult Delete(MAYANH pr)
        {
            MAYANH mAYANH = new MAYANH();
            mAYANH = db.MAYANHs.Find(pr.IDMAY);
            if (mAYANH != null)
            {
                db.MAYANHs.Remove(pr);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin()
        {
            
            string us = Request.Form["us"];
            string mk = Request.Form["mk"];
            var result = db.NHANVIENs.Where(p => p.TAIKHOAN == us && p.MATKHAU == mk);
            if (result.Count()>0)
            {
                return RedirectToAction("List");
            }
            else
            {
                TempData["msg"] = "Đăng nhập sai";
                return RedirectToAction("/Login");
            }
        }
        public ActionResult LeftMainLayout()
        {
            return PartialView();
        }
        public ActionResult Search(string tensp, string tenloaisp, string TuGia, string DenGia, int page = 1, int pageSize = 10)
        {

            List<LOAIMAY> cateLoaiSP = db.LOAIMAYs.ToList();
            if (page == 1 && tensp == null && tenloaisp == null && TuGia == null && DenGia == null)
            {
                tensp = Request.Form["txtTenSP"];
                tenloaisp = Request.Form["IDLOAIMAY"];
                TuGia = Request.Form["txtTuGia"];
                DenGia = Request.Form["txtDenGia"];
            }
            if (tenloaisp == null || tenloaisp == "") tenloaisp = "";
            else
            {
                LOAIMAY lp = new LOAIMAY();
                lp = (LOAIMAY)db.LOAIMAYs.Where(p => p.TENLMAY == tenloaisp).SingleOrDefault();
                cateLoaiSP.Remove(lp);

                LOAIMAY lp1 = new LOAIMAY();
                lp1.IDLOAIMAY = 0;
                lp1.TENLMAY = "";
                cateLoaiSP.Add(lp1);
            }
            
            ViewBag.TenSP = tensp;
            ViewBag.IDLOAIMAY = cateLoaiSP;
            ViewBag.TenLoaiSP = tenloaisp;
            ViewBag.TuGia = TuGia;
            ViewBag.DenGia = DenGia;

            if (TuGia == ""||TuGia==null)
            {
                TuGia = "0";
            }
            if (DenGia == ""||DenGia==null)
            {
                DenGia = "1000000000000000";
            }

            string query = string.Format("select IDMAY, TENMAY, HINHANH, DONGIA, MAYANH.IDLOAIMAY, LOAIMAY.TENLMAY from MAYANH,LOAIMAY where MAYANH.IDLOAIMAY = LOAIMAY.IDLOAIMAY and TENMAY like N'%"+tensp+"%' and TENLMAY like N'%" + tenloaisp + "%' and DONGIA >= " + TuGia + " and DONGIA <= " + DenGia);
            var lst = (db.Database.SqlQuery<CTMAYANH>(query).ToList()).ToPagedList(page, pageSize);
            return View(lst);
        }
    }
}