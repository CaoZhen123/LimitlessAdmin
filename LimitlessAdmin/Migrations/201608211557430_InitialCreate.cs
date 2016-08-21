namespace LimitlessAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 100),
                        Answer_Flag = c.Int(nullable: false),
                        Explanation = c.String(maxLength: 200),
                        Organization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Audit_Log",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Operation = c.String(nullable: false, maxLength: 50),
                        Time = c.DateTime(nullable: false),
                        Organization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "dbo.Objectives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        Organization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "dbo.ObjOfTops",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Objective_ID = c.Int(),
                        Organization_ID = c.Int(),
                        Topic_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Objectives", t => t.Objective_ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .ForeignKey("dbo.Topics", t => t.Topic_ID)
                .Index(t => t.Objective_ID)
                .Index(t => t.Organization_ID)
                .Index(t => t.Topic_ID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        Organization_ID = c.Int(),
                        Subject_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .ForeignKey("dbo.Subjects", t => t.Subject_ID, cascadeDelete: true)
                .Index(t => t.Organization_ID)
                .Index(t => t.Subject_ID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Descirption = c.String(maxLength: 150),
                        Icon = c.Int(nullable: false),
                        Organization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "dbo.QueOfSubObjs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Organization_ID = c.Int(),
                        Question_ID = c.Int(),
                        SubObjective_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .ForeignKey("dbo.Questions", t => t.Question_ID)
                .ForeignKey("dbo.SubObjectives", t => t.SubObjective_ID)
                .Index(t => t.Organization_ID)
                .Index(t => t.Question_ID)
                .Index(t => t.SubObjective_ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 255),
                        Organization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "dbo.SubObjectives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        NumberOfWrongGlobal = c.Int(nullable: false),
                        NumberOfCorrectGlobal = c.Int(nullable: false),
                        Organization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SubObjOfObjs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Objective_ID = c.Int(),
                        Organization_ID = c.Int(),
                        SubObjective_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Objectives", t => t.Objective_ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .ForeignKey("dbo.SubObjectives", t => t.SubObjective_ID)
                .Index(t => t.Objective_ID)
                .Index(t => t.Organization_ID)
                .Index(t => t.SubObjective_ID);
            
            CreateTable(
                "dbo.SystemSettings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Remark = c.String(maxLength: 100),
                        CreateTime = c.DateTime(nullable: false),
                        Organization_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID, cascadeDelete: true)
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SystemSettings", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.SubObjOfObjs", "SubObjective_ID", "dbo.SubObjectives");
            DropForeignKey("dbo.SubObjOfObjs", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.SubObjOfObjs", "Objective_ID", "dbo.Objectives");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.QueOfSubObjs", "SubObjective_ID", "dbo.SubObjectives");
            DropForeignKey("dbo.SubObjectives", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.QueOfSubObjs", "Question_ID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.QueOfSubObjs", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.ObjOfTops", "Topic_ID", "dbo.Topics");
            DropForeignKey("dbo.Topics", "Subject_ID", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.Topics", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.ObjOfTops", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.ObjOfTops", "Objective_ID", "dbo.Objectives");
            DropForeignKey("dbo.Objectives", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.Audit_Log", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.Answers", "Organization_ID", "dbo.Organizations");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SystemSettings", new[] { "Organization_ID" });
            DropIndex("dbo.SubObjOfObjs", new[] { "SubObjective_ID" });
            DropIndex("dbo.SubObjOfObjs", new[] { "Organization_ID" });
            DropIndex("dbo.SubObjOfObjs", new[] { "Objective_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SubObjectives", new[] { "Organization_ID" });
            DropIndex("dbo.Questions", new[] { "Organization_ID" });
            DropIndex("dbo.QueOfSubObjs", new[] { "SubObjective_ID" });
            DropIndex("dbo.QueOfSubObjs", new[] { "Question_ID" });
            DropIndex("dbo.QueOfSubObjs", new[] { "Organization_ID" });
            DropIndex("dbo.Subjects", new[] { "Organization_ID" });
            DropIndex("dbo.Topics", new[] { "Subject_ID" });
            DropIndex("dbo.Topics", new[] { "Organization_ID" });
            DropIndex("dbo.ObjOfTops", new[] { "Topic_ID" });
            DropIndex("dbo.ObjOfTops", new[] { "Organization_ID" });
            DropIndex("dbo.ObjOfTops", new[] { "Objective_ID" });
            DropIndex("dbo.Objectives", new[] { "Organization_ID" });
            DropIndex("dbo.Audit_Log", new[] { "Organization_ID" });
            DropIndex("dbo.Answers", new[] { "Organization_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SystemSettings");
            DropTable("dbo.SubObjOfObjs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SubObjectives");
            DropTable("dbo.Questions");
            DropTable("dbo.QueOfSubObjs");
            DropTable("dbo.Subjects");
            DropTable("dbo.Topics");
            DropTable("dbo.ObjOfTops");
            DropTable("dbo.Objectives");
            DropTable("dbo.Audit_Log");
            DropTable("dbo.Organizations");
            DropTable("dbo.Answers");
        }
    }
}
