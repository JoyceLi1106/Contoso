namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialInstructor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RolePeoples", newName: "PeopleRoles");
            DropPrimaryKey("dbo.PeopleRoles");
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
            AddPrimaryKey("dbo.PeopleRoles", new[] { "People_Id", "Role_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructor", "Id", "dbo.People");
            DropIndex("dbo.Instructor", new[] { "Id" });
            DropPrimaryKey("dbo.PeopleRoles");
            DropTable("dbo.Instructor");
            AddPrimaryKey("dbo.PeopleRoles", new[] { "Role_Id", "People_Id" });
            RenameTable(name: "dbo.PeopleRoles", newName: "RolePeoples");
        }
    }
}
