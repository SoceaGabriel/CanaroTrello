namespace Canaro_Trello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringguids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "UserIdString", c => c.String());
            AddColumn("dbo.Task", "ProjectIdString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Task", "ProjectIdString");
            DropColumn("dbo.Task", "UserIdString");
        }
    }
}
