namespace Canaro_Trello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatemodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "ProjectTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Project", "Version", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "Version", c => c.String());
            AlterColumn("dbo.Project", "ProjectTitle", c => c.String());
        }
    }
}
