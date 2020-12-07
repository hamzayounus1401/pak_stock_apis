using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRole1.Models;

namespace WebRole1.DTO
{
    public class StockDailyDto
    {
       
        public String code { set; get; }
        public DateTime? date { set; get; }
        public double? high { set; get; }
        public double? low { set; get; }
        public double open { set; get; }
        public double? close { set; get; }
        public double? volume { set; get; }
        public stock stock { set; get; }

    }
}