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

    public class stock_forcastingController : ApiController
    {
        private StockDbContext db = new StockDbContext();

      

       
            // GET: api/StockPrediction/5
        [ResponseType(typeof(stock_forcasting))]
        public IHttpActionResult Getstock_forcasting(DateTime date)
        {
            try
            {
                //db.Configuration.ProxyCreationEnabled = false;

                List<stock_forcasting> stock_Forcastings = new List<stock_forcasting>();

                stock_Forcastings = (db.Stock_Forcastings.Where(s => s.prediction_date == date)).ToList<stock_forcasting>();
                if (stock_Forcastings == null)
                {
                    return NotFound();
                }

                return Ok(stock_Forcastings);
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
             new HttpError(e.ToString())));
            }
        }
    

      
       

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool stock_forcastingExists(int id)
        {
            return false;//db.Stock_Forcastings.Count(e => e.id == id) > 0;
        }
    }
}