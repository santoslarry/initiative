namespace initiative.sso.db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCompany",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblTest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Roles_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblRoles", t => t.Roles_Id)
                .ForeignKey("dbo.tblUsers", t => t.Users_Id)
                .Index(t => t.Roles_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCompany", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserRoles", "Users_Id", "dbo.tblUsers");
            DropForeignKey("dbo.tblUsers", "Company_Id", "dbo.tblCompany");
            DropForeignKey("dbo.tblUserRoles", "Roles_Id", "dbo.tblRoles");
            DropIndex("dbo.tblUsers", new[] { "Company_Id" });
            DropIndex("dbo.tblUserRoles", new[] { "Users_Id" });
            DropIndex("dbo.tblUserRoles", new[] { "Roles_Id" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblUserRoles");
            DropTable("dbo.tblTest");
            DropTable("dbo.tblRoles");
            DropTable("dbo.tblCompany");
        }
    }
}
