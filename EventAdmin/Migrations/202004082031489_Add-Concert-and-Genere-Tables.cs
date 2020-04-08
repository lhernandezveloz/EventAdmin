namespace EventAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConcertandGenereTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Concerts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Artist_Id = c.String(nullable: false, maxLength: 128),
                        Genere_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Generes", t => t.Genere_Id, cascadeDelete: true)
                .Index(t => t.Artist_Id)
                .Index(t => t.Genere_Id);
            
            CreateTable(
                "dbo.Generes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 225),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Concerts", "Genere_Id", "dbo.Generes");
            DropForeignKey("dbo.Concerts", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Concerts", new[] { "Genere_Id" });
            DropIndex("dbo.Concerts", new[] { "Artist_Id" });
            DropTable("dbo.Generes");
            DropTable("dbo.Concerts");
        }
    }
}
