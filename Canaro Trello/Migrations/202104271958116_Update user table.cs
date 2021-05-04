namespace Canaro_Trello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateusertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "ConfirmedPassword", c => c.String(nullable: false));
            AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "LastName", c => c.String());
            AlterColumn("dbo.User", "FirstName", c => c.String());
            DropColumn("dbo.User", "ConfirmedPassword");
        }
    }
}
