using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebRole1.Models
{
    
    public partial class stock_signal

    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonIgnore]
        public int id { get; set; }

        [Column("signal_date")]
        public DateTime date_ { get; set; }

        [Column("macd_signals")]
        public int macd_signals{ set; get; }
    [StringLength(50)]

        [Column("bollinger_signals")]
        public String bollinger_signals { set; get; }
        [ForeignKey("stock")]
        



        public int stock_id { get; set; }
        
        public virtual stock stock { get; set; }
    }
}