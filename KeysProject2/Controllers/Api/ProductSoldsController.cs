using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KeysProject2.Models;

namespace KeysProject2.Controllers.Api
{
    public class ProductSoldsController : ApiController
    {
        private MVC2Entities db = new MVC2Entities();

        // GET: api/ProductSolds
        public IQueryable<ProductSold> GetProductSolds()
        {
            return db.ProductSolds;
        }

        // GET: api/ProductSolds/5
        [ResponseType(typeof(ProductSold))]
        public IHttpActionResult GetProductSold(int id)
        {
            ProductSold productSold = db.ProductSolds.Find(id);
            if (productSold == null)
            {
                return NotFound();
            }

            return Ok(productSold);
        }

        // PUT: api/ProductSolds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductSold(int id, ProductSold productSold)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productSold.Id)
            {
                return BadRequest();
            }

            db.Entry(productSold).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSoldExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductSolds
        [ResponseType(typeof(ProductSold))]
        public IHttpActionResult PostProductSold(ProductSold productSold)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductSolds.Add(productSold);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productSold.Id }, productSold);
        }

        // DELETE: api/ProductSolds/5
        [ResponseType(typeof(ProductSold))]
        public IHttpActionResult DeleteProductSold(int id)
        {
            ProductSold productSold = db.ProductSolds.Find(id);
            if (productSold == null)
            {
                return NotFound();
            }

            db.ProductSolds.Remove(productSold);
            db.SaveChanges();

            return Ok(productSold);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductSoldExists(int id)
        {
            return db.ProductSolds.Count(e => e.Id == id) > 0;
        }
    }
}