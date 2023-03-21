namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelation2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Order_Id", "dbo.Orders");
            //DropIndex("dbo.Orders", new[] { "User_Username" });
            DropIndex("dbo.Users", new[] { "Order_Id" });
           // DropColumn("dbo.Orders", "OrderedBy");
            //RenameColumn(table: "dbo.Orders", name: "User_Username", newName: "OrderedBy");
            DropColumn("dbo.Users", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Order_Id", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "OrderedBy", newName: "User_Username");
            AddColumn("dbo.Orders", "OrderedBy", c => c.String(maxLength: 10));
            CreateIndex("dbo.Users", "Order_Id");
            CreateIndex("dbo.Orders", "User_Username");
            AddForeignKey("dbo.Users", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
