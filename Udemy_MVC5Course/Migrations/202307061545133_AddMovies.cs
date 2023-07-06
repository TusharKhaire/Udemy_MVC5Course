namespace Udemy_MVC5Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        M_id = c.Int(nullable: false, identity: true),
                        M_Name = c.String(),
                    })
                .PrimaryKey(t => t.M_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
