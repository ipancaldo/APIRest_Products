using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Logic;
using Api_ABM;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Web.Http.Cors;

namespace Api_ABM.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ApiABMController : ApiController
    {
        private ProductsLogic productsLogic = new ProductsLogic();

        // GET => READ
        [ResponseType(typeof(ProductsView))]
        public List<ProductsView> Get()
        {
            var products = productsLogic.GetAll();

            var productsViewList = products.Select(p => new ProductsView
                                                    {
                                                       Id = p.ProductID,
                                                       Name = p.ProductName,
                                                       QuantityPerUnit = p.QuantityPerUnit,
                                                       Price = (decimal)p.UnitPrice
                                                    }).ToList();
            return productsViewList;
        }
        
        // GET => READ
        [ResponseType(typeof(ProductsView))]
        public IHttpActionResult GetProducts(int id)
        {
            Products products = productsLogic.GetData(id);
            if (products == null)   return NotFound();

            ProductsView productsView = new ProductsView
                                    {
                                        Id = products.ProductID,
                                        Name = products.ProductName,
                                        QuantityPerUnit = products.QuantityPerUnit,
                                        Price = (decimal)products.UnitPrice
                                    };
            return Ok(productsView);
        }

        // PUT => REPLACE
        [ResponseType(typeof(void))]
        /* Pasamos una vista para que sea más fácil de editar el JSON y luego 
        lo transformamos en un Products para se pueda actualizar */
        public IHttpActionResult PutProducts(/*int id, */ProductsView productsView) 
        {
            Products product = new Products
                                        {
                                            ProductID = productsView.Id,
                                            ProductName = productsView.Name,
                                            QuantityPerUnit = productsView.QuantityPerUnit,
                                            UnitPrice = productsView.Price,
                                        };

            if (!ModelState.IsValid) return BadRequest(ModelState);

            //if (id != product.ProductID) return BadRequest();

            try
            {
                productsLogic.Update(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }   

        // POST => INSERT
        [ResponseType(typeof(void))]
        public IHttpActionResult PostProducts(ProductsView productsView)
        {
            Products product = new Products
                                        {
                                            ProductName = productsView.Name,
                                            QuantityPerUnit = productsView.QuantityPerUnit,
                                            UnitPrice = productsView.Price,
                                        };

            if (!ModelState.IsValid)    return BadRequest(ModelState);

            productsLogic.Add(product);

            //Para retornar en la vista el ID correcto y no 0
            productsView.Id = product.ProductID;

            //return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, productsView);
            return Ok();
        }

        // DELETE => DELETE
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteProducts(int id)
        {
            Products product = productsLogic.GetData(id);
            if (product == null)    return NotFound();

            productsLogic.Delete(id);

            ProductsView productsView = new ProductsView
                                            {
                                                Id = product.ProductID,
                                                Name = product.ProductName,
                                                QuantityPerUnit = product.QuantityPerUnit,
                                                Price = (decimal)product.UnitPrice
                                            };
            return Ok();
        }
    }
}