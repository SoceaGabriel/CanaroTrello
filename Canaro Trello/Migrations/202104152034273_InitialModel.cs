namespace Canaro_Trello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Guid(nullable: false, identity: true),
                        ProjectTitle = c.String(),
                        ProjectDescription = c.String(),
                        Version = c.String(),
                        ProjectStartDate = c.DateTime(nullable: false),
                        Complexity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Guid(nullable: false, identity: true),
                        TaskTitle = c.String(),
                        State = c.Int(nullable: false),
                        Type = c.String(),
                        Priority = c.Int(nullable: false),
                        UserId = c.Guid(),
                        ProjectId = c.Guid(),
                        TaskStardDate = c.DateTime(),
                        TaskEndDate = c.DateTime(),
                        EstimatedTime = c.String(),
                        TaskDescription = c.String(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Task", "UserId", "dbo.User");
            DropIndex("dbo.Task", new[] { "ProjectId" });
            DropIndex("dbo.Task", new[] { "UserId" });
            DropTable("dbo.User");
            DropTable("dbo.Task");
            DropTable("dbo.Project");
        }
    }
}
