using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class stock_prediction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonIgnore]
        public int id { get; set; }

        [Column("prediction_date")]
        public DateTime prediction_date { get; set; }

        [Column("rf_prediction")]
        public float rf_prediction { set; get; }
        [ForeignKey("stock")]
        [JsonIgnore]
        public int stock_id { get; set; }
       
        public virtual stock stock { get; set; }
    }
}