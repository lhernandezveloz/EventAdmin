namespace EventAdmin.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateDataOnGenereTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Name) Values ('Rock')");
            Sql("Insert into Genres (Name) Values ('Pop')");
            Sql("Insert into Genres (Name) Values ('Rap')");
            Sql("Insert into Genres (Name) Values ('Country')");
        }

        public override void Down()
        {
            Sql("Delete from Genres where Id in (1, 2, 3, 4)");
        }
    }
}
