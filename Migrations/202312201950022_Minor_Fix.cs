namespace PhotoStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Minor_Fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Paid", c => c.Int(nullable: false));
            AddColumn("dbo.Photographers", "VacationUntil", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photographers", "VacationUntil");
            DropColumn("dbo.Orders", "Paid");
        }
    }
}
