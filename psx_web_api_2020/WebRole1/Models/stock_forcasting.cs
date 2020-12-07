using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class stock_forcasting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonIgnore]
        public int id { get; set; }

        [Column("forcasting_date")]
        public DateTime prediction_date { get; set; }

        [Column("arima_forcasting")]
        public float arima_forcasting { set; get; }
        [ForeignKey("stock")]
        [JsonIgnore]
        public int stock_id { get; set; }
      
        public virtual stock stock { get; set; }
    }
}