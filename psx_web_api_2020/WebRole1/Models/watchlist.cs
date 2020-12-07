namespace WebRole1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("watchlist")]
    public partial class watchlist
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string user_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stock_id { get; set; }

        public virtual stock stock { get; set; }

        public virtual user_stockify user_stockify { get; set; }
    }
}
