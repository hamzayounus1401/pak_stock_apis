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
    public class StockPredictionController : ApiController
    {
        private StockDbContext db = new StockDbContext();

      
        // GET: api/StockPrediction/5
        [ResponseType(typeof(stock_prediction))]
        public IHttpActionResult Getstock_prediction(DateTime date)
        {
            try
            {
//                db.Configuration.ProxyCreationEnabled = false;

                List<stock_prediction> stock_predictions = new List<stock_prediction>();

                stock_predictions = (db.Stock_Predictions.Where(s => s.prediction_date == date)).ToList<stock_prediction>();
                if (stock_predictions == null)
                {
                    return NotFound();
                }

                return Ok(stock_predictions);
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

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool stock_predictionExists(int id)
        {
            return db.Stock_Predictions.Count(e => e.id == id) > 0;
        }
    }
}