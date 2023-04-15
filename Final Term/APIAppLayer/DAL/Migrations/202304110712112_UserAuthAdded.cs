namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAuthAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Username", c => c.String());
            AddColumn("dbo.Employees", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "Username");
        }
    }
}
