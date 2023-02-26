namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PK_FKStudent_Dept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "DepartmentId");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropColumn("dbo.Students", "DepartmentId");
        }
    }
}
