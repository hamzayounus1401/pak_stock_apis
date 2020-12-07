namespace WebRole1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signals1whyy : DbMigration
    {
        public override void Up()
        {
            
   
            DropForeignKey("dbo.portfolio_details", new[] { "portfolio_id1", "portfolio_user_id1", "portfolio_stock_id1" }, "dbo.portfolio");
           
           
            DropIndex("dbo.portfolio_details", new[] { "portfolio_id1", "portfolio_user_id1", "portfolio_stock_id1" });
  
    
         

          
      
        
            CreateIndex("dbo.portfolio_details", new[] { "portfolio_id", "portfolio_user_id", "portfolio_stock_id" });
         
  
            AddForeignKey("dbo.portfolio_details", new[] { "portfolio_id", "portfolio_user_id", "portfolio_stock_id" }, "dbo.portfolio", new[] { "id", "user_id", "stock_id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.portfolio_details", new[] { "portfolio_id", "portfolio_user_id", "portfolio_stock_id" }, "dbo.portfolio");
            DropForeignKey("dbo.watchlist", "stock_id", "dbo.stock");
            DropForeignKey("dbo.portfolio", "stock_id", "dbo.stock");
            DropIndex("dbo.watchlist", new[] { "stock_id" });
            DropIndex("dbo.watchlist", new[] { "user_id" });
            DropIndex("dbo.stock_data", new[] { "stock_id" });
            DropIndex("dbo.portfolio_details", new[] { "portfolio_id", "portfolio_user_id", "portfolio_stock_id" });
            DropIndex("dbo.portfolio", new[] { "stock_id" });
            DropIndex("dbo.portfolio", new[] { "user_id" });
            DropIndex("dbo.notification_registration", new[] { "user_id" });
            DropPrimaryKey("dbo.watchlist");
            DropPrimaryKey("dbo.portfolio");
            AlterColumn("dbo.watchlist", "user_id", c => c.String(maxLength: 128));
            AlterColumn("dbo.watchlist", "stock_id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.stock_data", "stock_id", c => c.Int());
            AlterColumn("dbo.stock", "code", c => c.String(maxLength: 11));
            AlterColumn("dbo.stock", "name", c => c.String(maxLength: 50));
            AlterColumn("dbo.portfolio_details", "portfolio_stock_id", c => c.Int());
            AlterColumn("dbo.portfolio_details", "portfolio_user_id", c => c.String(maxLength: 128));
            AlterColumn("dbo.portfolio_details", "portfolio_id", c => c.Int());
            AlterColumn("dbo.portfolio", "user_id", c => c.String(maxLength: 128));
            AlterColumn("dbo.portfolio", "name", c => c.String(maxLength: 50));
            AlterColumn("dbo.portfolio", "stock_id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.user_stockify", "phonenumber", c => c.String(maxLength: 15));
            AlterColumn("dbo.user_stockify", "email", c => c.String(maxLength: 50));
            AlterColumn("dbo.user_stockify", "name", c => c.String(maxLength: 50));
            AlterColumn("dbo.notification_registration", "user_id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.watchlist", new[] { "id", "user_id", "stock_id" });
            AddPrimaryKey("dbo.portfolio", new[] { "id", "user_id", "stock_id" });
            RenameColumn(table: "dbo.watchlist", name: "stock_id", newName: "id");
            RenameColumn(table: "dbo.stock_data", name: "stock_id", newName: "stock_id1");
            RenameColumn(table: "dbo.portfolio", name: "stock_id", newName: "id");
            RenameColumn(table: "dbo.portfolio_details", name: "portfolio_stock_id", newName: "portfolio_stock_id1");
            RenameColumn(table: "dbo.portfolio_details", name: "portfolio_user_id", newName: "portfolio_user_id1");
            RenameColumn(table: "dbo.portfolio_details", name: "portfolio_id", newName: "portfolio_id1");
            RenameColumn(table: "dbo.watchlist", name: "user_id", newName: "user_stockify_id");
            RenameColumn(table: "dbo.portfolio", name: "user_id", newName: "user_stockify_id");
            RenameColumn(table: "dbo.notification_registration", name: "user_id", newName: "user_stockify_id");
            AddColumn("dbo.watchlist", "stock_id", c => c.Int(nullable: false));
            AddColumn("dbo.watchlist", "user_id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.stock_data", "stock_id", c => c.Int(nullable: false));
            AddColumn("dbo.portfolio_details", "portfolio_stock_id", c => c.Int(nullable: false));
            AddColumn("dbo.portfolio_details", "portfolio_user_id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.portfolio_details", "portfolio_id", c => c.Int(nullable: false));
            AddColumn("dbo.portfolio", "stock_id", c => c.Int(nullable: false));
            AddColumn("dbo.portfolio", "user_id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.notification_registration", "user_id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.watchlist", "user_stockify_id");
            CreateIndex("dbo.watchlist", "id");
            CreateIndex("dbo.stock_data", "stock_id1");
            CreateIndex("dbo.portfolio_details", new[] { "portfolio_id1", "portfolio_user_id1", "portfolio_stock_id1" });
            CreateIndex("dbo.portfolio", "user_stockify_id");
            CreateIndex("dbo.portfolio", "id");
            CreateIndex("dbo.notification_registration", "user_stockify_id");
            AddForeignKey("dbo.portfolio_details", new[] { "portfolio_id1", "portfolio_user_id1", "portfolio_stock_id1" }, "dbo.portfolio", new[] { "id", "user_id", "stock_id" });
            AddForeignKey("dbo.watchlist", "id", "dbo.stock", "id", cascadeDelete: true);
            AddForeignKey("dbo.portfolio", "id", "dbo.stock", "id", cascadeDelete: true);
        }
    }
}
