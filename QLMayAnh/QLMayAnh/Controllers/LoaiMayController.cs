using PagedList;
using QLMayAnh.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLMayAnh.Controllers
{
    public class LoaiMayController : Controller
    {
        // GET: LoaiMay
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
                var lst = (db.LOAIMAYs.SqlQuery("select * from LoaiMay").ToList<LOAIMAY>()).ToPagedList(page, pagesize);
                return View(lst);
            }
        }

        public ActionResult Create()
        {
            if (Session["us"] == null) return RedirectToAction("Login", "MayAnh");
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(LOAIMAY pr)
        {
            db.LOAIMAYs.Add(pr);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            if (Session["us"] == null) return RedirectToAction("Login", "MayAnh");
            else
            {
                LOAIMAY pr = new LOAIMAY();
                pr = db.LOAIMAYs.Find(id);
                return View(pr);
            }
        }
        [HttpPost]
        public ActionResult Edit(LOAIMAY pr)
        {
            LOAIMAY lOAIMAY = new LOAIMAY();
            lOAIMAY = db.LOAIMAYs.Find(pr.IDLOAIMAY);
            if (lOAIMAY != null)
            {
                lOAIMAY.TENLMAY= pr.TENLMAY;
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            if (Session["us"] == null) return RedirectToAction("Login", "MayAnh");
            else
            {
                LOAIMAY pr = new LOAIMAY();
                pr = db.LOAIMAYs.Find(id);
                return View(pr);
            }
        }
        [HttpPost]
        public ActionResult Delete(LOAIMAY pr)
        {
            LOAIMAY lOAIMAY = new LOAIMAY();
            lOAIMAY = db.LOAIMAYs.Find(pr.IDLOAIMAY);
            if (lOAIMAY != null)
            {
                db.LOAIMAYs.Remove(pr);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}