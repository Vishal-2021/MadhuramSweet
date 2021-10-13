namespace Accounting_Final_Details.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WearhousValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wearhouses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Wearhouses", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wearhouses", "Address", c => c.String());
            AlterColumn("dbo.Wearhouses", "Name", c => c.String());
        }
    }
}
