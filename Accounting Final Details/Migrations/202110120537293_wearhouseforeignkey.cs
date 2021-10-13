namespace Accounting_Final_Details.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wearhouseforeignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "Tax", c => c.String());
            AddColumn("dbo.ProductDetails", "WearhouseRefId", c => c.Int());
            AddForeignKey("dbo.ProductDetails", "WearhouseRefId", "dbo.Wearhouses", "Id");
            CreateIndex("dbo.ProductDetails", "WearhouseRefId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductDetails", new[] { "WearhouseRefId" });
            DropForeignKey("dbo.ProductDetails", "WearhouseRefId", "dbo.Wearhouses");
            DropColumn("dbo.ProductDetails", "WearhouseRefId");
            DropColumn("dbo.ProductDetails", "Tax");
        }
    }
}
