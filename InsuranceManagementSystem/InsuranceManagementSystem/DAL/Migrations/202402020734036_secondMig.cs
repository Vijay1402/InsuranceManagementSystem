namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Policies", "DateOfCreation", c => c.DateTime(nullable: false));
            DropColumn("dbo.Policies", "AppliedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Policies", "AppliedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Policies", "DateOfCreation");
        }
    }
}
