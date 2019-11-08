namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialPeopleandRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        UnitOrApartmentNumber = c.Int(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        IsLocked = c.String(),
                        LastLockedDateTime = c.DateTime(nullable: false),
                        FailedAttempts = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolePeoples",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        People_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.People_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.People_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.People_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolePeoples", "People_Id", "dbo.People");
            DropForeignKey("dbo.RolePeoples", "Role_Id", "dbo.Roles");
            DropIndex("dbo.RolePeoples", new[] { "People_Id" });
            DropIndex("dbo.RolePeoples", new[] { "Role_Id" });
            DropTable("dbo.RolePeoples");
            DropTable("dbo.Roles");
            DropTable("dbo.People");
        }
    }
}
