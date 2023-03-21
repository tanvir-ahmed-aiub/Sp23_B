using PMS.Auth;
using PMS.EF;
using PMS.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        [Logged]
        public ActionResult Index(int id=1) //id means page number
        {
           
            PMSContext db = new PMSContext();
            int itemperpage = 10;
            int total = db.Products.Count();
            int pages = (int)Math.Ceiling(total / (double)itemperpage);
            ViewBag.pages = pages;

            var products = db.Products.OrderBy(p => p.Id).Skip((id - 1) * itemperpage).Take(itemperpage).ToList();

            return View(products);
        }
        public ActionResult AddCart(int id) {
            PMSContext db = new PMSContext();
            var product = db.Products.Find(id); 

            List<Product> cart = null;
            if (Session["cart"] == null)
            {
                cart = new List<Product>();
            }
            else {
                cart = (List<Product>)Session["cart"];
            }
            
            cart.Add(new Product() { 
                Id = product.Id,
                Name = product.Name,    
                Price = product.Price,
                Qty = 1,
            });
            db.SaveChanges();
            Session["cart"] = cart;
            TempData["Msg"] = "Successfully Added";
            TempData["Color"] = "alert-success";
            return RedirectToAction("Index");
        }
        public ActionResult Cart() {
            if (Session["cart"]!=null)
                return View((List<Product>)Session["cart"]);
            TempData["Msg"] = "Cart Empty";
            TempData["Color"] = "alert-info";
            return RedirectToAction("Index");
        }
        public ActionResult Place() {
            PMSContext db = new PMSContext();
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.Status = "Ordered";
            order.Total = 0;
            db.Orders.Add(order);
            db.SaveChanges();
            var products = (List<Product>)Session["cart"];

            foreach (var item in products)
            {
                OrderDetail od = new OrderDetail();
                od.OId = order.Id;
                od.PId = item.Id;
                od.Qty = item.Qty;
                od.UnitPrice = item.Price;
                order.Total += item.Price * item.Qty;
                db.OrderDetails.Add(od);
            }
            db.SaveChanges();
            Session["cart"] = null;
            TempData["Msg"] = "Order Placed Successfully";
            TempData["Color"] = "alert-success";
            return RedirectToAction("Index");

        }
    }
}