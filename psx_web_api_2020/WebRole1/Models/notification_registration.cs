namespace WebRole1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class notification_registration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [StringLength(264)]
        public string f_token { get; set; }

        [Required]
        [StringLength(128)]
        public string user_id { get; set; }

        public virtual user_stockify user_stockify { get; set; }
    }
}
