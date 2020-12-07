namespace WebRole1.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("portfolio")]
    public partial class portfolio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public portfolio()
        {
            portfolio_details = new HashSet<portfolio_details>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [Column(Order = 0)]
      
        
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Key]
        [Column(Order = 1)]
       
        public string user_id { get; set; }

        [Key]
        [Column(Order = 2)]
       
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stock_id { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<portfolio_details> portfolio_details { get; set; }
        [JsonIgnore]
        public virtual stock stock { get; set; }
        [JsonIgnore]
        public virtual user_stockify user_stockify { get; set; }
    }
}
