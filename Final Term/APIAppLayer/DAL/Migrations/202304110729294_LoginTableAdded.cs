namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            DropColumn("dbo.Employees", "Username");
            DropColumn("dbo.Employees", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Employees", "Username", c => c.String());
            DropTable("dbo.Logins");
        }
    }
}
