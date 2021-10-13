namespace Accounting_Final_Details.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredtowearhousekey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDetails", "WearhouseRefId", "dbo.Wearhouses");
            DropIndex("dbo.ProductDetails", new[] { "WearhouseRefId" });
            AlterColumn("dbo.ProductDetails", "WearhouseRefId", c => c.Int(nullable: false));
            AddForeignKey("dbo.ProductDetails", "WearhouseRefId", "dbo.Wearhouses", "Id", cascadeDelete: true);
            CreateIndex("dbo.ProductDetails", "WearhouseRefId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductDetails", new[] { "WearhouseRefId" });
            DropForeignKey("dbo.ProductDetails", "WearhouseRefId", "dbo.Wearhouses");
            AlterColumn("dbo.ProductDetails", "WearhouseRefId", c => c.Int());
            CreateIndex("dbo.ProductDetails", "WearhouseRefId");
            AddForeignKey("dbo.ProductDetails", "WearhouseRefId", "dbo.Wearhouses", "Id");
        }
    }
}
