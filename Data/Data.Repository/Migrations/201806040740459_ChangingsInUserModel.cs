namespace Data.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingsInUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "HangedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DeletedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DeletedAt");
            DropColumn("dbo.Users", "HangedAt");
            DropColumn("dbo.Users", "UpdatedAt");
            DropColumn("dbo.Users", "Email");
        }
    }
}
