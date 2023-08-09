using Microsoft.AspNet.Identity;
using MyWork.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WingtipToys.Logic;

namespace MyWork.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            //Get Cart User
            ShoppingCartActions actions = new ShoppingCartActions();
            List<CartItem> cartItems = actions.GetCartItems();
            //Count price
            decimal cartTotal = 0;
            cartTotal = actions.GetTotal();
            if (cartTotal > 0)
            {
                // Display Total.                     
                ViewBag.Total = String.Format("{0:c}", cartTotal);
            }
            else
            {
                ViewBag.TotalText = "0";
                ViewBag.Total = "0";
                ViewBag.Title = "Shopping Cart is Empty";
            }
            return View(cartItems);
        }
        //Add Product To Cart
        public void AddCart(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }
            }
            else
            {
                Debug.Fail("خطایی به وجو اومده لطفا دوباره تلاش کنید.");
                throw new Exception("خطایی به وجو اومده لطفا دوباره تلاش کنید.");
            }
            Response.Redirect("Index");
        }
        //Remove Product In The Cart
        public void RemoveItem(int productID)
        {
            using (var _db = new MyWork.Models.ApplicationDbContext())
            {
                try
                {
                    var myItem = (from c in _db.ShoppingCartItems where  c.Couerses.Id == productID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        _db.ShoppingCartItems.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("خطایی به وجو اومده لطفا دوباره تلاش کنید." + exp.Message.ToString(), exp);
                }
            }
            Response.Redirect("Index");

        }

    }
}