namespace EventAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingAttencesCollection1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "Concert_Id", "dbo.Concerts");
            DropIndex("dbo.Attendances", new[] { "Concert_Id" });
            DropColumn("dbo.Attendances", "Concert_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "Concert_Id", c => c.Int());
            CreateIndex("dbo.Attendances", "Concert_Id");
            AddForeignKey("dbo.Attendances", "Concert_Id", "dbo.Concerts", "Id");
        }
    }
}
