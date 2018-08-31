using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWITHJSONINWCF_Client.Models;
using CRUDWITHJSONINWCF_Client.ViewModels;

namespace CRUDWITHJSONINWCF_Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductServiceClient psc = new ProductServiceClient();
            ViewBag.listProducts = psc.findall();

            return View();
        }
        [HttpGet]
        public ActionResult create()
        {
            return View("create");
        }
        public ActionResult create(ProdductViewModel pvm)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.Create(pvm.product);
            return RedirectToAction("Index");
           
        }

        public ActionResult Delete( string id)
        { ProductServiceClient psc = new ProductServiceClient();
            psc.delete (psc.find (id));
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Edit(string id)
        {
            ProductServiceClient psc = new ProductServiceClient();
            ProdductViewModel pvm = new ProdductViewModel();
            pvm.product = psc.find(id);
            return View ("Edit", pvm );
          }
        [HttpPost]
        public ActionResult Edit(ProdductViewModel pvm)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.edit(pvm.product);
            return RedirectToAction("Index", "Product");

        }
    }
}