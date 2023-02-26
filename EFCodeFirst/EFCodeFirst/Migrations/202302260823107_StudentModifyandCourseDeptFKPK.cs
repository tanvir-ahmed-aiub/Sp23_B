namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentModifyandCourseDeptFKPK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Description", c => c.String());
            AddColumn("dbo.Courses", "OfferdBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Students", "Cgpa", c => c.Single());
            CreateIndex("dbo.Courses", "OfferdBy");
            AddForeignKey("dbo.Courses", "OfferdBy", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "OfferdBy", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "OfferdBy" });
            AlterColumn("dbo.Students", "Cgpa", c => c.Single(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            DropColumn("dbo.Courses", "OfferdBy");
            DropColumn("dbo.Courses", "Description");
        }
    }
}
