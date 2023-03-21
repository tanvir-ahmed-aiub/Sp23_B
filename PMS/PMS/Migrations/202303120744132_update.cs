namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OrderedBy", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "OrderedBy" });
            AlterColumn("dbo.Orders", "OrderedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderedBy", c => c.String(maxLength: 10));
            CreateIndex("dbo.Orders", "OrderedBy");
            AddForeignKey("dbo.Orders", "OrderedBy", "dbo.Users", "Username");
        }
    }
}
