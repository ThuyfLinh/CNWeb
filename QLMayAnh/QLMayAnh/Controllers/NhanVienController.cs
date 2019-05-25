//using QLMayAnh.Models;
using PagedList;
using QLMayAnh.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLMayAnh.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        ShopModelsData db = new ShopModelsData();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int page =1 , int pageSize = 10)
        {
            var lst = (db.NHANVIENs.SqlQuery("select * from NhanVien").ToList<NHANVIEN>()).ToPagedList(page,pageSize);
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NHANVIEN pr)
        {
            db.NHANVIENs.Add(pr);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Edit(int id)
        {
            NHANVIEN pr = new NHANVIEN();
            pr = db.NHANVIENs.Find(id);
            return View(pr);
        }
        [HttpPost]
        public ActionResult Edit(NHANVIEN pr)
        {
            NHANVIEN nHANVIEN = new NHANVIEN();
            nHANVIEN = db.NHANVIENs.Find(pr.IDNV);
            if(nHANVIEN!=null)
            {
                nHANVIEN.TENNV = pr.TENNV;
                nHANVIEN.SDT = pr.SDT;
                nHANVIEN.TAIKHOAN = pr.TAIKHOAN;
                nHANVIEN.MATKHAU = pr.MATKHAU;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            NHANVIEN pr = new NHANVIEN();
            pr = db.NHANVIENs.Find(id);
            return View(pr);
        }
        [HttpPost]
        public ActionResult Delete(NHANVIEN pr)
        {
            NHANVIEN nHANVIEN = new NHANVIEN();
            nHANVIEN = db.NHANVIENs.Find(pr.IDNV);
            if (nHANVIEN != null)
            {
                db.NHANVIENs.Remove(pr);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}