namespace WebRole1.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class stock_data
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonIgnore]
        public int id { get; set; }

        public DateTime? datadate { get; set; }

        public double low{ get; set; }

        public double  high { get; set; }

        public double  open { get; set; }

        public double  close { get; set; }

        public double  volume { get; set; }
        [JsonIgnore]
        public int stock_id { get; set; }
        [JsonIgnore]
        public virtual stock stock { get; set; }
    }
}
