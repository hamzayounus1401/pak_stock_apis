namespace WebRole1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signals1ww : DbMigration
    {
        public override void Up()
        {
          
          
            AlterColumn("dbo.portfolio_details", "pricepershare", c => c.Double(nullable: false));
            AlterColumn("dbo.portfolio_details", "profit", c => c.Double());
            AlterColumn("dbo.portfolio_details", "valueForCalculating", c => c.Double());
           
          
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.watchlist", "id", "dbo.stock");
            DropForeignKey("dbo.stock_data", "stock_id1", "dbo.stock");
            DropForeignKey("dbo.portfolio", "id", "dbo.stock");
            DropForeignKey("dbo.portfolio_details", new[] { "portfolio_id1", "portfolio_user_id1", "portfolio_stock_id1" }, "dbo.portfolio");
            DropForeignKey("dbo.watchlist", "user_stockify_id", "dbo.user_stockify");
            DropForeignKey("dbo.portfolio", "user_stockify_id", "dbo.user_stockify");
            DropForeignKey("dbo.notification_registration", "user_stockify_id", "dbo.user_stockify");
            DropIndex("dbo.watchlist", new[] { "user_stockify_id" });
            DropIndex("dbo.watchlist", new[] { "id" });
            DropIndex("dbo.stock_data", new[] { "stock_id1" });
            DropIndex("dbo.portfolio_details", new[] { "portfolio_id1", "portfolio_user_id1", "portfolio_stock_id1" });
            DropIndex("dbo.portfolio", new[] { "user_stockify_id" });
            DropIndex("dbo.portfolio", new[] { "id" });
            DropIndex("dbo.notification_registration", new[] { "user_stockify_id" });
            DropPrimaryKey("dbo.watchlist");
            DropPrimaryKey("dbo.portfolio");
            AlterColumn("dbo.watchlist", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.stock", "code", c => c.String(maxLength: 11, unicode: false));
            AlterColumn("dbo.stock", "name", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.portfolio_details", "valueForCalculating", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.portfolio_details", "profit", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.portfolio_details", "pricepershare", c => c.Decimal(nullable: false, precision: 28, scale: 0, storeType: "numeric"));
            AlterColumn("dbo.portfolio", "name", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.portfolio", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.user_stockify", "phonenumber", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.user_stockify", "email", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.user_stockify", "name", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.watchlist", "user_stockify_id");
            DropColumn("dbo.stock_data", "stock_id1");
            DropColumn("dbo.portfolio_details", "portfolio_stock_id1");
            DropColumn("dbo.portfolio_details", "portfolio_user_id1");
            DropColumn("dbo.portfolio_details", "portfolio_id1");
            DropColumn("dbo.portfolio", "user_stockify_id");
            DropColumn("dbo.notification_registration", "user_stockify_id");
            AddPrimaryKey("dbo.watchlist", new[] { "id", "user_id", "stock_id" });
            AddPrimaryKey("dbo.portfolio", new[] { "id", "user_id", "stock_id" });
            RenameColumn(table: "dbo.watchlist", name: "id", newName: "stock_id");
            RenameColumn(table: "dbo.portfolio", name: "id", newName: "stock_id");
            AddColumn("dbo.watchlist", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.portfolio", "id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.watchlist", "stock_id");
            CreateIndex("dbo.watchlist", "user_id");
            CreateIndex("dbo.stock_data", "stock_id");
            CreateIndex("dbo.portfolio_details", new[] { "portfolio_id", "portfolio_user_id", "portfolio_stock_id" });
            CreateIndex("dbo.portfolio", "stock_id");
            CreateIndex("dbo.portfolio", "user_id");
            CreateIndex("dbo.notification_registration", "user_id");
            AddForeignKey("dbo.watchlist", "stock_id", "dbo.stock", "id");
            AddForeignKey("dbo.stock_data", "stock_id", "dbo.stock", "id");
            AddForeignKey("dbo.portfolio", "stock_id", "dbo.stock", "id");
            AddForeignKey("dbo.portfolio_details", new[] { "portfolio_id", "portfolio_user_id", "portfolio_stock_id" }, "dbo.portfolio", new[] { "id", "user_id", "stock_id" });
            AddForeignKey("dbo.watchlist", "user_id", "dbo.user_stockify", "id");
            AddForeignKey("dbo.portfolio", "user_id", "dbo.user_stockify", "id");
            AddForeignKey("dbo.notification_registration", "user_id", "dbo.user_stockify", "id");
        }
    }
}
