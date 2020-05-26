namespace EventAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingAttencesCollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "Concert_Id", c => c.Int());
            CreateIndex("dbo.Attendances", "Concert_Id");
            AddForeignKey("dbo.Attendances", "Concert_Id", "dbo.Concerts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "Concert_Id", "dbo.Concerts");
            DropIndex("dbo.Attendances", new[] { "Concert_Id" });
            DropColumn("dbo.Attendances", "Concert_Id");
        }
    }
}
