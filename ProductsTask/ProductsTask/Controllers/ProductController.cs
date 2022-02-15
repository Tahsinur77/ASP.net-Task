using ProductsTask.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProductsTask.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        [HttpGet]
        public ActionResult Show()
        {
            Products_taskEntities db = new Products_taskEntities();
            var productList = db.Products.ToList();
            return View(productList);
        }
        [HttpGet]
        public ActionResult AddCart()
        {

            if (Session["cart"] != null) 
            { 
                var x = Session["cart"].ToString();
                List<Product> plist = new JavaScriptSerializer().Deserialize<List<Product>>(x);
                return View(plist);
            }
            else
            {
                List<Product> plist = new List<Product>();
                return View(plist);
            }
            
        }

        
        public ActionResult AddingProcess(int id)
        {
            Products_taskEntities db = new Products_taskEntities();
            db.Configuration.ProxyCreationEnabled = false;
            Product p = (from pro in db.Products
                     where pro.Id.Equals(id)
                     select pro).FirstOrDefault();
            

            if (Session["cart"] == null)
            {
       
                List<Product> plist = new List<Product>();
                plist.Add(p);
               
                string jsonProductCart = new JavaScriptSerializer().Serialize(plist);
                Session["cart"] = jsonProductCart;
                return RedirectToAction("Addcart");
            }
            else
            {
                var x = Session["cart"].ToString();
                List<Product> plist = new JavaScriptSerializer().Deserialize<List<Product>>(x);
                plist.Add(p);
                string jsonProductCart = new JavaScriptSerializer().Serialize(plist);
                Session["cart"] = jsonProductCart;
                return RedirectToAction("Addcart");
            } 
        }

        [HttpGet]
        public ActionResult OrderList()
        {
            Products_taskEntities db = new Products_taskEntities();
            var orderList = db.Orders.ToList();
            return View(orderList);
        }


        public ActionResult OrderPlace()
        {
            if(Session["cart"] != null)
            {
                var x = Session["cart"].ToString();
                List<Product> plist = new JavaScriptSerializer().Deserialize<List<Product>>(x);

                Session.Remove("cart");

                Order od = new Order();
                od.CustomerId = 1;
                od.Status = "Painding";
                Products_taskEntities db = new Products_taskEntities();
                db.Orders.Add(od);
                db.SaveChanges();

                foreach (var i in plist)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = od.OrderId;
                    orderDetail.ProductId = i.Id;
                    orderDetail.OrderQty = 1;
                    Products_taskEntities dbOrderDetails = new Products_taskEntities();
                    dbOrderDetails.OrderDetails.Add(orderDetail);
                    dbOrderDetails.SaveChanges();
                }
            }



            return RedirectToAction("OrderList");
        }

    }
}