namespace Accounting_Final_Details.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wearhousekey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TempDataPurchases", "WearhouseRefID", c => c.Int());
            AddForeignKey("dbo.TempDataPurchases", "WearhouseRefID", "dbo.Wearhouses", "Id");
            CreateIndex("dbo.TempDataPurchases", "WearhouseRefID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TempDataPurchases", new[] { "WearhouseRefID" });
            DropForeignKey("dbo.TempDataPurchases", "WearhouseRefID", "dbo.Wearhouses");
            DropColumn("dbo.TempDataPurchases", "WearhouseRefID");
        }
    }
}
