using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CRUDSample.UI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Home()
        {
            NortwindEntities db = new NortwindEntities();
            List<Product> urunListesi = db.Products.ToList();
            return View(urunListesi);
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Product eklenecekVeri)
        {
            NortwindEntities db = new NortwindEntities();
            db.Products.Add(eklenecekVeri);
            int donenVeri = db.SaveChanges();

            if (donenVeri > 0)
            {
                return RedirectToAction("Home");
            }
            else
            {
                return RedirectToAction("Hata");
            }
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            NortwindEntities db=new NortwindEntities();
            Product secilenUrun = db.Products.SingleOrDefault(a => a.ProductID==id);
            return View(secilenUrun);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product guncellenecekVeri)
        {
            NortwindEntities db = new NortwindEntities();
            Product secilenVeri = db.Products.Find(guncellenecekVeri.ProductID);

            if (secilenVeri != null)
            {
                secilenVeri.ProductName = guncellenecekVeri.ProductName;
                secilenVeri.CategoryID = guncellenecekVeri.CategoryID;
                secilenVeri.UnitsInStock = guncellenecekVeri.UnitsInStock;
                int donenVeri = db.SaveChanges();
                if (donenVeri > 0)
                {
                    return RedirectToAction("Home");
                }
                    return RedirectToAction("Hata");
            }
                return RedirectToAction("Hata");
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            NortwindEntities db = new NortwindEntities();
            Product secilenUrun = db.Products.SingleOrDefault(a => a.ProductID == id);
            return View(secilenUrun);
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product silinecekVeri)
        {
            NortwindEntities db=new NortwindEntities();
            var secilenVeri=db.Products.Find(silinecekVeri.ProductID);

            if (secilenVeri!=null)
            {
                db.Products.Remove(secilenVeri);
                int donenDeger=db.SaveChanges();
                if (donenDeger>0)
                {
                    return RedirectToAction("Home");
                }
                    return RedirectToAction("Hata");
            }
                return RedirectToAction("Hata");
        }
    }
}

