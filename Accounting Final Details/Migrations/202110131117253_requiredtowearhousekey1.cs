namespace Accounting_Final_Details.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredtowearhousekey1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId", c => c.Int(nullable: false));
            AddForeignKey("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId", "dbo.Wearhouses", "Id", cascadeDelete: true);
            CreateIndex("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TempSalesBillWithoutGstDtls", new[] { "WearhouseRefId" });
            DropForeignKey("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId", "dbo.Wearhouses");
            DropColumn("dbo.TempSalesBillWithoutGstDtls", "WearhouseRefId");
        }
    }
}
