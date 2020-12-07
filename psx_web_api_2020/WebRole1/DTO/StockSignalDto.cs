using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRole1.Models;

namespace WebRole1.DTO
{
    public class StockSignalDto
    {

        
        public DateTime date_ { get; set; }

    
        public int macd_signals { set; get; }
     

      
        public String bollinger_signals { set; get; }
        


        public stock stock { get; set; }
    }
}