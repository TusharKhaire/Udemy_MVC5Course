namespace Udemy_MVC5Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveReFGonreFromMovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_Id" });
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "genre_Id");
            AddForeignKey("dbo.Movies", "genre_Id", "dbo.Genres", "Id");
        }
    }
}
