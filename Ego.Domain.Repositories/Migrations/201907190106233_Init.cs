namespace Ego.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dish",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Comment = c.String(),
                        Score = c.Double(),
                        Restaurant_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Restaurant", t => t.Restaurant_ID)
                .Index(t => t.Restaurant_ID);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dish", "Restaurant_ID", "dbo.Restaurant");
            DropIndex("dbo.Dish", new[] { "Restaurant_ID" });
            DropTable("dbo.Restaurant");
            DropTable("dbo.Dish");
        }
    }
}
