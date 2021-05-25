namespace Canaro_Trello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
     
    public partial class Space : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Task", "TaskTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Task", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Task", "TaskStardDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Task", "EstimatedTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Task", "EstimatedTime", c => c.String());
            AlterColumn("dbo.Task", "TaskStardDate", c => c.DateTime());
            AlterColumn("dbo.Task", "Type", c => c.String());
            AlterColumn("dbo.Task", "TaskTitle", c => c.String());
        }
    }
}
