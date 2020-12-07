using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRole1.DTO
{
    public class PortfolioDetailDto
    {
        public DateTime? dateofpurchase { get; set; }
        [Required]
        public int? noofshares { get; set; }
        [Required]
        
        public double? pricepershare { get; set; }

        public double? profit { get; set; }
        [Required]
        public int portfolio_id { get; set; }
        [Required]
        [StringLength(128)]
        public string Action { get; set; }

        [Required]
        [StringLength(128)]
        public string portfolio_user_id { get; set; }
        [Required]
        public int portfolio_stock_id { get; set; }
    }
}