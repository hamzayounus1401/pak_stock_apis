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
using WebRole1.DTO;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public class PortfolioDetailsController : ApiController
    {
        private StockDbContext db = new StockDbContext();

        // GET: api/PortfolioDetails
        public IHttpActionResult Getportfolio_details(String user_id)
        {
            List<PortfolioDetailDto> dto = new List<PortfolioDetailDto>();
            List<portfolio_details> portfolio_Details =  db.portfolio_details.Where(v=>v.portfolio_user_id == user_id).ToList<portfolio_details>();
            foreach(portfolio_details p in portfolio_Details)
            {
                
                    PortfolioDetailDto portfolioDetailDto = new PortfolioDetailDto();
                    portfolioDetailDto.portfolio_id = p.portfolio_id;
                    portfolioDetailDto.portfolio_stock_id = p.portfolio_stock_id;
                    portfolioDetailDto.pricepershare = p.pricepershare;
                    portfolioDetailDto.noofshares = p.noofshares;
                    portfolioDetailDto.dateofpurchase = p.dateofpurchase;
                    portfolioDetailDto.Action = p.Action;
                    portfolioDetailDto.profit = p.profit;
                    dto.Add(portfolioDetailDto);

                
            }
            return Ok(dto);
        }

        // GET: api/PortfolioDetails/5
        //[ResponseType(typeof(portfolio_details))]
        //public IHttpActionResult Getportfolio_details(int id)
        //{
        //    portfolio_details portfolio_details = db.portfolio_details.Find(id);
        //    if (portfolio_details == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(portfolio_details);
        //}

        // PUT: api/PortfolioDetails/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putportfolio_details(int id, portfolio_details portfolio_details)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != portfolio_details.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(portfolio_details).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!portfolio_detailsExists(id))
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

        // POST: api/PortfolioDetails
        [ResponseType(typeof(portfolio_details))]
        public IHttpActionResult Postportfolio_details(portfolio_details portfolios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (portfolios.Action == "buy")
            {
                portfolios.profit = 0;
                portfolios.valueForCalculating = 0;
                int? noOfShares = 0;
                portfolio_details temp = db.portfolio_details.Where(v=>v.portfolio_user_id == portfolios.portfolio_user_id).OrderByDescending(x => x.id).FirstOrDefault();
               
                if (temp != null)
                {
                    noOfShares = noOfShares + temp.noofshares;

                    portfolios.valueForCalculating = temp.valueForCalculating;
                
                }
                
                portfolios.valueForCalculating = portfolios.valueForCalculating + (portfolios.noofshares * portfolios.pricepershare);

                portfolios.noofshares = portfolios.noofshares + noOfShares;
            
                db.portfolio_details.Add(portfolios);
                db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = portfolios.id }, portfolios);
            }
            else if(portfolios.Action == "sell")
            {
                portfolios.valueForCalculating = 0;
                portfolio_details temp = db.portfolio_details.Where(v => v.portfolio_user_id == portfolios.portfolio_user_id).OrderByDescending(x => x.id).FirstOrDefault();
                
                if (temp == null || temp.noofshares == 0 || temp.noofshares<portfolios.noofshares)
                {
                    return  new System.Web.Http.Results.ResponseMessageResult(
         Request.CreateErrorResponse((HttpStatusCode)400,
             new HttpError("You have no shares or low shares to sell")));
                }
                else
                {
                    portfolios.valueForCalculating = temp.valueForCalculating;
                    double? minus = (temp.valueForCalculating / temp.noofshares);

                    portfolios.profit = (((portfolios.noofshares) * ( portfolios.pricepershare)) - ((minus) * (portfolios.noofshares)));
                    portfolios.valueForCalculating = temp.valueForCalculating - ((minus) * (portfolios.noofshares));

                    portfolios.noofshares = temp.noofshares - portfolios.noofshares;
                    if (portfolios.valueForCalculating <= 0 || portfolios.noofshares==0)
                        portfolios.valueForCalculating = 0;
                    db.portfolio_details.Add(portfolios);
                    
                    db.SaveChanges();
                    return CreatedAtRoute("DefaultApi", new { id = portfolios.id }, portfolios);
                }
               

            }
            else
            {
                return new System.Web.Http.Results.ResponseMessageResult(
         Request.CreateErrorResponse((HttpStatusCode)400,
             new HttpError("Action values should be (buy,sell)")));
            }

           
        }

        // DELETE: api/PortfolioDetails/5
        //[ResponseType(typeof(portfolio_details))]
        //public IHttpActionResult Deleteportfolio_details(int id)
        //{
        //    portfolio_details portfolio_details = db.portfolio_details.Find(id);
        //    if (portfolio_details == null)
        //    {
        //        return NotFound();
        //    }

        //    db.portfolio_details.Remove(portfolio_details);
        //    db.SaveChanges();

        //    return Ok(portfolio_details);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool portfolio_detailsExists(int id)
        {
            return db.portfolio_details.Count(e => e.id == id) > 0;
        }
    }
}