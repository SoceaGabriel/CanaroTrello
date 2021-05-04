namespace Canaro_Trello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addrolestousertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Role", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Role");
        }
    }
}
