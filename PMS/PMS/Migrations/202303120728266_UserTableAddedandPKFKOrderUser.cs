namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableAddedandPKFKOrderUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 20),
                        Type = c.String(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            AddColumn("dbo.Orders", "OrderedBy", c => c.String(maxLength: 10));
            CreateIndex("dbo.Orders", "OrderedBy");
            AddForeignKey("dbo.Orders", "OrderedBy", "dbo.Users", "Username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "OrderedBy", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "OrderedBy" });
            DropColumn("dbo.Orders", "OrderedBy");
            DropTable("dbo.Users");
        }
    }
}
