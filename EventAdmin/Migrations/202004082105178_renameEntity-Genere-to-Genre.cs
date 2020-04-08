namespace EventAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameEntityGeneretoGenre : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Generes", newName: "Genres");
            RenameColumn(table: "dbo.Concerts", name: "Genere_Id", newName: "Genre_Id");
            RenameIndex(table: "dbo.Concerts", name: "IX_Genere_Id", newName: "IX_Genre_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Concerts", name: "IX_Genre_Id", newName: "IX_Genere_Id");
            RenameColumn(table: "dbo.Concerts", name: "Genre_Id", newName: "Genere_Id");
            RenameTable(name: "dbo.Genres", newName: "Generes");
        }
    }
}
