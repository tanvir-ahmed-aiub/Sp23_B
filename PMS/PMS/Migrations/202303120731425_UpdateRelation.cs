namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "User_Username", c => c.String(maxLength: 10));
            CreateIndex("dbo.Orders", "User_Username");
            AddForeignKey("dbo.Orders", "User_Username", "dbo.Users", "Username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Username", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_Username" });
            DropColumn("dbo.Orders", "User_Username");
        }
    }
}
