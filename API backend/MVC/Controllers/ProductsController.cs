using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using Entities;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        ProductsLogic logic = new ProductsLogic();

        // GET: Products
        public ActionResult Index()
        {
            try
            {
                List<Products> products = logic.GetAll();

                List<ProductsView> productsViews = products.Select(p => new ProductsView
                {
                    Id = p.ProductID,
                    Name = p.ProductName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    Price = (decimal)p.UnitPrice
                }).ToList();

                return View(productsViews);
            }
            catch (Exception ex)
            {
                LogErrorsLogic logErrorsLogic = new LogErrorsLogic();
                logErrorsLogic.LogError(ex.Message);

                TempData["MensajeError"] = "There was a problem trying to load the products. " + ex.Message;
                return RedirectToAction("Index", "Error", ex);
            }


            
        }

        public ActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Desde acá podemos logear el error en un TXT que se guarda en D:/
                LogErrorsLogic logErrorsLogic = new LogErrorsLogic();
                logErrorsLogic.LogError(ex.Message);

                TempData["MensajeError"] = ex.Message;
                return RedirectToAction("Index", "Error", ex);
            }
        }

        public ActionResult Insert()
        {
            return View("InsertEdit", new ProductsView());
        }

        public ActionResult Edit(int id)
        {
            List<Products> products = logic.GetAll();

            List<ProductsView> productsView = products.Where(p => p.ProductID == id).Select(p => new ProductsView
            {
                Id = p.ProductID,
                Name = p.ProductName,
                QuantityPerUnit = p.QuantityPerUnit,
                Price = (decimal)p.UnitPrice
            }).ToList();

            ProductsView productView = productsView[0];

            return View("InsertEdit", productView);
        }

        [HttpPost]
        public ActionResult InsertEdit(ProductsView productsView)
        {
            if (ModelState.IsValid)
            {
                if (productsView.Id <= 0)
                {
                    try
                    {

                        Products productEntity = new Products
                        {
                            ProductName = productsView.Name,
                            QuantityPerUnit = productsView.QuantityPerUnit,
                            UnitPrice = productsView.Price,
                        };

                        logic.Add(productEntity);

                        return RedirectToAction("Index");
                    }
                    catch (FormatException ex)
                    {
                        string error = $"Price error, non-numeric value was entered. Error: {ex.Message}";
                        TempData["MensajeError"] = error;

                        LogErrorsLogic logErrorsLogic = new LogErrorsLogic();
                        logErrorsLogic.LogError(error);

                        return RedirectToAction("Index", "Error");
                    }
                    catch (Exception ex)
                    {
                        LogErrorsLogic logErrorsLogic = new LogErrorsLogic();
                        logErrorsLogic.LogError(ex.Message);

                        TempData["MensajeError"] = "There was a problem trying to save the product. Please go back and try again";
                        return RedirectToAction("Index", "Error");
                    }
                }
                else
                {
                    try
                    {
                        Products productEntity = new Products
                        {
                            ProductID = productsView.Id,
                            ProductName = productsView.Name,
                            QuantityPerUnit = productsView.QuantityPerUnit,
                            UnitPrice = productsView.Price,
                        };

                        logic.Update(productEntity);

                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        LogErrorsLogic logErrorsLogic = new LogErrorsLogic();
                        logErrorsLogic.LogError(ex.Message);

                        TempData["MensajeError"] = "There was a problem trying to save the product. Please go back and try again";
                        return RedirectToAction("Index", "Error");
                    }
                }
            }
            return View();
        }
    }
}