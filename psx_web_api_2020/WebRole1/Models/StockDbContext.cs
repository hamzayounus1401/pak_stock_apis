namespace WebRole1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StockDbContext : DbContext
    {
        public StockDbContext()
            : base("name=StockDbContext")
        {
        }

        public virtual DbSet<notification_registration> notification_registration { get; set; }
        public virtual DbSet<portfolio> portfolios { get; set; }
        public virtual DbSet<portfolio_details> portfolio_details { get; set; }
        public virtual DbSet<stock> stocks { get; set; }
        public virtual DbSet<stock_data> stock_data { get; set; }
        public virtual DbSet<user_stockify> user_stockify { get; set; }
        public virtual DbSet<watchlist> watchlists { get; set; }
        public virtual DbSet<stock_signal> Stock_Signals { get; set; }
        public virtual DbSet<stock_prediction> Stock_Predictions { get; set; }
       public virtual DbSet<stock_forcasting> Stock_Forcastings { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<portfolio>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<portfolio>()
                .HasMany(e => e.portfolio_details)
                .WithRequired(e => e.portfolio)
                .HasForeignKey(e => new { e.portfolio_id, e.portfolio_user_id, e.portfolio_stock_id })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<portfolio_details>()
                .Property(e => e.pricepershare);


            modelBuilder.Entity<stock>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<stock>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<stock>()
                .HasMany(e => e.portfolios)
                .WithRequired(e => e.stock)
                .HasForeignKey(e => e.stock_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stock>()
                .HasMany(e => e.stock_data)
                .WithRequired(e => e.stock)
                .HasForeignKey(e => e.stock_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stock>()
                .HasMany(e => e.watchlists)
                .WithRequired(e => e.stock)
                .HasForeignKey(e => e.stock_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_stockify>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user_stockify>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user_stockify>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<user_stockify>()
                .HasMany(e => e.notification_registration)
                .WithRequired(e => e.user_stockify)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_stockify>()
                .HasMany(e => e.portfolios)
                .WithRequired(e => e.user_stockify)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_stockify>()
                .HasMany(e => e.watchlists)
                .WithRequired(e => e.user_stockify)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
