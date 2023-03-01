namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ODPriceDTChnanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Int(nullable: false));
        }
    }
}
