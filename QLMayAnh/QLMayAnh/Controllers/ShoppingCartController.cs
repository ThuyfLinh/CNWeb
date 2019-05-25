using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLMayAnh.Models.Entity;

namespace QLMayAnh.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Add(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            ShopModelsData db = new ShopModelsData();
            MAYANH pr = db.MAYANHs.Find(id);
            if (pr != null)
            {
                cart.InsertItem(pr.IDMAY, pr.TENMAY, (double)pr.DONGIA);
            }
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Remove(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.RemoveItem(id);
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Update(int id,FromCollection f)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();

            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}