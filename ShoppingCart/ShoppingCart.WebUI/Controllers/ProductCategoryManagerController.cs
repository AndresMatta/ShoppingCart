using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Core.Models;
using ShoppingCart.DataAccess.InMemory;

namespace ShoppingCart.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        ProductCategoryRepository context;

        public ProductCategoryManagerController()
        {
            context = new ProductCategoryRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
           
            context.Insert(productCategory);
            context.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);

            if (productCategory == null)
            {
                return HttpNotFound();
            }

            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory product, string Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
           
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            productCategoryToEdit.Category = product.Category;
            context.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }

            return View(productCategoryToDelete);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }

            context.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}