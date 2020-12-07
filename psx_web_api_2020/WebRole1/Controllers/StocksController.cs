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
using WebRole1.DTO;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    [Authorize]
    public class StocksController : ApiController
    {
        private StockDbContext db = new StockDbContext();


        // GET: api/Stocks
        public IHttpActionResult Getstocks()
        {
            try
            {
                List<StockDto> stock = db.stocks.Select(s => new StockDto { code = s.code, name = s.name }).ToList();
                return Ok(stock);
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

        // GET: api/Stocks/5
        //[ResponseType(typeof(stock))]
        //public IHttpActionResult Getstock(int id)
        //{
        //    try
        //    {
        //        stock stock = db.stocks.Find(id);
        //        if (stock == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(stock);
        //    }
        //    catch(Exception e)
        //    {
        //        return Ok(e.Message);
        //    }
            
        //}

        [ResponseType(typeof(stock))]
        public IHttpActionResult Getstock(String code)
        {
            try
            {
                stock stock = db.stocks.FirstOrDefault(s => s.code == code);

                if (stock == null)
                {
                    return NotFound();
                }
                StockDto stockDto = new StockDto();
                stockDto.code = stock.code;
                stockDto.name = stock.name;

                return Ok(stockDto);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [ResponseType(typeof(stock))]
        public IHttpActionResult Getstock(DateTime date)
        {

            //List<StockDailyDto> stockDailyDtos =  db.stock_data.Where(s=>s.datadate.Value.Month.Equals("12"))
            // .Select(s=>new StockDailyDto {open=s.open, close= s.close, date=s.datadate, high=s.high, low=s.low, volume=s.volume}).ToList();

            try
            {
                List<StockDailyDto> list = db.stock_data
                   //.Where(s => s.datadate.Value.Month.Equals(date.Month) && s.datadate.Value.Year.Equals(date.Year) && s.datadate.Value.Day.Equals(date.Day))
                     .Where(s=>s.datadate == date)                    
.Select(s => new StockDailyDto { date = s.datadate, close = s.close, high = s.high, low = s.low, open = s.open, volume = s.volume, code = s.stock.code, stock  = s.stock  }).ToList();


                return Ok(list);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }


        //// PUT: api/Stocks/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putstock(int id, stock stock)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != stock.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(stock).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!stockExists(id))
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

        //// POST: api/Stocks
        //[ResponseType(typeof(stock))]
        //public IHttpActionResult Poststock(stock stock)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.stocks.Add(stock);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = stock.id }, stock);
        //}

        //// DELETE: api/Stocks/5
        //[ResponseType(typeof(stock))]
        //public IHttpActionResult Deletestock(int id)
        //{
        //    stock stock = db.stocks.Find(id);
        //    if (stock == null)
        //    {
        //        return NotFound();
        //    }

        //    db.stocks.Remove(stock);
        //    db.SaveChanges();

        //    return Ok(stock);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool stockExists(int id)
        {
            return db.stocks.Count(e => e.id == id) > 0;
        }
    }
}