namespace Accounting_Final_Details.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wearhousekeyremove1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesBillWithoutGstDtls", "WearhouseRefId", c => c.Int());
            AddForeignKey("dbo.SalesBillWithoutGstDtls", "WearhouseRefId", "dbo.Wearhouses", "Id");
            CreateIndex("dbo.SalesBillWithoutGstDtls", "WearhouseRefId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SalesBillWithoutGstDtls", new[] { "WearhouseRefId" });
            DropForeignKey("dbo.SalesBillWithoutGstDtls", "WearhouseRefId", "dbo.Wearhouses");
            DropColumn("dbo.SalesBillWithoutGstDtls", "WearhouseRefId");
        }
    }
}
