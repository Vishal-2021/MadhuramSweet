namespace Accounting_Final_Details.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wearhousekeyremove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId", "dbo.Wearhouses");
            DropIndex("dbo.TempSalesBillWithoutGstDtls", new[] { "WearhouseRefId" });
            AlterColumn("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId", c => c.Int());
            AddForeignKey("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId", "dbo.Wearhouses", "Id");
            CreateIndex("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TempSalesBillWithoutGstDtls", new[] { "WearhouseRefId" });
            DropForeignKey("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId", "dbo.Wearhouses");
            AlterColumn("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId");
            AddForeignKey("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId", "dbo.Wearhouses", "Id", cascadeDelete: true);
        }
    }
}
