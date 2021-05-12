namespace Canaro_Trello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableguid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "UserId", "dbo.User");
            DropForeignKey("dbo.Task", "ProjectId", "dbo.Project");
            DropIndex("dbo.Task", new[] { "UserId" });
            DropIndex("dbo.Task", new[] { "ProjectId" });
            AlterColumn("dbo.Task", "UserId", c => c.Guid());
            AlterColumn("dbo.Task", "ProjectId", c => c.Guid());
            CreateIndex("dbo.Task", "UserId");
            CreateIndex("dbo.Task", "ProjectId");
            AddForeignKey("dbo.Task", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Task", "ProjectId", "dbo.Project", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Task", "UserId", "dbo.User");
            DropIndex("dbo.Task", new[] { "ProjectId" });
            DropIndex("dbo.Task", new[] { "UserId" });
            AlterColumn("dbo.Task", "ProjectId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Task", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Task", "ProjectId");
            CreateIndex("dbo.Task", "UserId");
            AddForeignKey("dbo.Task", "ProjectId", "dbo.Project", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Task", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
    }
}
