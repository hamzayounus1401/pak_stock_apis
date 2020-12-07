namespace WebRole1.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class portfolio_details
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime? dateofpurchase { get; set; }
        [Required]
        public int? noofshares { get; set; }
        [Required]
  
        public double? pricepershare { get; set; }
        [Required]
    

        public int portfolio_id { get; set; }
        [Required]
        [StringLength(128)]
        public string Action { get; set; }

        [Required]
        [StringLength(128)]
        

        public string portfolio_user_id { get; set; }
        [JsonIgnore]
        public double? profit { get; set; }
        [JsonIgnore]
        public double? valueForCalculating { get; set; }
        [Required]
     
        public int portfolio_stock_id { get; set; }
        [JsonIgnore]
        [ForeignKey("portfolio_stock_id,portfolio_user_id,portfolio_id")]
        public virtual portfolio portfolio { get; set; }
    }
}
