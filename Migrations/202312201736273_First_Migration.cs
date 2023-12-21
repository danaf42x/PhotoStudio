namespace PhotoStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                        Photographer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Customer_Id)
                .ForeignKey("dbo.Photographers", t => t.Photographer_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Photographer_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronym = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Passport = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photographers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronym = c.String(),
                        PhoneNumber = c.String(),
                        Passport = c.String(),
                        DayStartHour = c.Int(nullable: false),
                        DayEndHour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Customer_Id", "dbo.People");
            DropForeignKey("dbo.Orders", "Photographer_Id", "dbo.Photographers");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.People");
            DropIndex("dbo.Users", new[] { "Customer_Id" });
            DropIndex("dbo.Orders", new[] { "Photographer_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Photographers");
            DropTable("dbo.People");
            DropTable("dbo.Orders");
        }
    }
}
