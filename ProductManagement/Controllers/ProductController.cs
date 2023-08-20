using Newtonsoft.Json;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        productTBDataContext pdb = new productTBDataContext();
        // GET: Product
        public ActionResult Index(string productsJson)
        {
            if (productsJson != null)
            {
                List<ProductTable> productsData = JsonConvert.DeserializeObject<List<ProductTable>>(productsJson);
                return View(productsData);
            }
            else
                return View(pdb.ProductTables.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            ProductTable p = pdb.ProductTables.Where(pr => pr.pId == id).FirstOrDefault();
            return View(p);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductTable collection)
        {
            try
            {
                // TODO: Add insert logic here
                pdb.ProductTables.InsertOnSubmit(collection);
                pdb.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductTable p = pdb.ProductTables.Where(pr => pr.pId == id).FirstOrDefault();

            return View(p);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductTable collection)
        {
            try
            {
                ProductTable p = pdb.ProductTables.Where(pr => pr.pId == id).FirstOrDefault();

                p.pname = collection.pname;
                p.price = collection.price;
                p.quantity = collection.quantity;
                p.description = collection.description;

                pdb.SubmitChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            ProductTable p = pdb.ProductTables.Where(pr => pr.pId == id).FirstOrDefault();

            return View(p);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductTable collection)
        {
            try
            {
                ProductTable p = pdb.ProductTables.Where(pr => pr.pId == id).FirstOrDefault();

                pdb.ProductTables.DeleteOnSubmit(p);

                pdb.SubmitChanges();

                return RedirectToAction("Index");
                // TODO: Add delete logic here

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search()
        {
            return View(pdb.ProductTables);
        }

        [HttpPost]
        public ActionResult Search(string SearchPname)
        {
            try
            {
                List<ProductTable> Sprd = (from p in pdb.ProductTables
                                           where p.pname.ToUpper().Contains(SearchPname.ToUpper())
                                           select p).ToList();

                return View(Sprd);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchByObject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByObject(ProductTable prd)
        {
            try
            {
                List<ProductTable> Sprd;

                if (prd.pname != null)
                {

                    Sprd = (from p in pdb.ProductTables
                            where p.pname.ToUpper().Contains(prd.pname.ToUpper())
                            select p).ToList();

                }
                else if(prd.price!=null)
                {
                    Sprd = (from p in pdb.ProductTables
                            where p.price <= prd.price
                            select p).ToList();
                }
                else if(prd.quantity != null)
                {
                    Sprd = (from p in pdb.ProductTables
                            where p.quantity >= prd.quantity
                            select p).ToList();
                }
                else
                {
                    Sprd = (from p in pdb.ProductTables
                            where p.description.ToUpper().Contains(prd.description.ToUpper())
                            select p).ToList();

                }
                string productsJson = JsonConvert.SerializeObject(Sprd);

                return RedirectToAction("index", new { productsJson });
            }
            catch
            {
                return View();
            }
        }
    }
}
