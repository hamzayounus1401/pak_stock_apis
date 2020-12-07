using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    [Authorize]
    public class PortfoliosController : ApiController
    {
        private StockDbContext db = new StockDbContext();

        // GET: api/Portfolios
        public IQueryable<portfolio> Getportfolios(String user_id)
        {
            return db.portfolios.Where(v=>v.user_id == user_id);
        }

        // GET: api/Portfolios/5
        [ResponseType(typeof(portfolio))]
        public IHttpActionResult Getportfolio(int id)
        {
            portfolio portfolio = db.portfolios.Find(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio);
        }

        //// PUT: api/Portfolios/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putportfolio(int id, portfolio portfolio)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != portfolio.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(portfolio).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!portfolioExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Portfolios
        [ResponseType(typeof(portfolio))]
        public IHttpActionResult Postportfolio(portfolio portfolio)
        {
            bool yes = false;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                List<portfolio> portfolios = db.portfolios.Where(v => v.user_id == portfolio.user_id).ToList<portfolio>();
                foreach(portfolio p in portfolios)
                {
                    if (p.name == portfolio.name)
                        yes = true;
                }

                if (yes)
                {
                    return new System.Web.Http.Results.ResponseMessageResult(
               Request.CreateErrorResponse((HttpStatusCode)409,
                   new HttpError("Portfolio name already exists")));
                }
                else
                {
                    db.portfolios.Add(portfolio);
                    db.SaveChanges();

                    return CreatedAtRoute("DefaultApi", new { id = portfolio.id }, portfolio);
                }
            }
            catch (SqlException e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
           Request.CreateErrorResponse((HttpStatusCode)500,
               new HttpError(e.Message)));

            }

            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
         Request.CreateErrorResponse((HttpStatusCode)500,
             new HttpError(e.Message)));
            }

        }

        // DELETE: api/Portfolios/5
        //[ResponseType(typeof(portfolio))]
        //public IHttpActionResult Deleteportfolio(int id)
        //{
        //    portfolio portfolio = db.portfolios.Find(id);
        //    if (portfolio == null)
        //    {
        //        return NotFound();
        //    }

        //    db.portfolios.Remove(portfolio);
        //    db.SaveChanges();

        //    return Ok(portfolio);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool portfolioExists(int id)
        {
            return db.portfolios.Count(e => e.id == id) > 0;
        }
    }
}