namespace Accounting_Final_Details.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wearhouseforeignkey1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseDtls", "WearhouseRefID", c => c.Int());
            AddForeignKey("dbo.PurchaseDtls", "WearhouseRefID", "dbo.Wearhouses", "Id");
            CreateIndex("dbo.PurchaseDtls", "WearhouseRefID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PurchaseDtls", new[] { "WearhouseRefID" });
            DropForeignKey("dbo.PurchaseDtls", "WearhouseRefID", "dbo.Wearhouses");
            DropColumn("dbo.PurchaseDtls", "WearhouseRefID");
        }
    }
}
