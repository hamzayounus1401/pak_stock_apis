using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Globalization;
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
    public class stock_signalController : ApiController
    {
        private StockDbContext db = new StockDbContext();

       

        // GET: api/stock_signal/5
        [ResponseType(typeof(stock_signal))]
        public IHttpActionResult Getstock_signal(DateTime date)
        {
            try
            {
               // db.Configuration.ProxyCreationEnabled = false;

                List<stock_signal> stock_signal = new List<stock_signal>();

                stock_signal = (db.Stock_Signals.Where(s => s.date_ == date)).ToList<stock_signal>();
                if (stock_signal == null)
                {
                    return NotFound();
                }
                List<StockSignalDto> newList = new List<StockSignalDto>();
                foreach(stock_signal s in stock_signal)
                {
                    StockSignalDto dto = new StockSignalDto();
                    dto.stock = s.stock;
                    dto.bollinger_signals = s.bollinger_signals;
                    dto.date_ = s.date_;
                    dto.macd_signals = s.macd_signals;
                    newList.Add(dto);
                }
                return Ok(newList);
            }catch(SqlException e)
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

        // PUT: api/stock_signal/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putstock_signal(int id, stock_signal stock_signal)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != stock_signal.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(stock_signal).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!stock_signalExists(id))
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

        // POST: api/stock_signal
        //[ResponseType(typeof(stock_signal))]
        //public IHttpActionResult Poststock_signal(stock_signal stock_signal)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Stock_Signals.Add(stock_signal);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = stock_signal.id }, stock_signal);
        //}

        // DELETE: api/stock_signal/5
      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool stock_signalExists(int id)
        {
            return db.Stock_Signals.Count(e => e.id == id) > 0;
        }
    }
}