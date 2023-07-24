namespace Udemy_MVC5Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnotationsInMovies : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "M_Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "M_Name", c => c.String());
        }
    }
}
