namespace EventAdmin.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateConcerttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concerts", "Venue", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Concerts", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Concerts", "Date");
        }

        public override void Down()
        {
            AddColumn("dbo.Concerts", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Concerts", "DateTime");
            DropColumn("dbo.Concerts", "Venue");
        }
    }
}
