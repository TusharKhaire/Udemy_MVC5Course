namespace Udemy_MVC5Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMembershiptypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("Update MembershipTypes set Name='Pay as You Go' Where Id=1");
            Sql("Update MembershipTypes set Name='Monthly' Where Id=2");
            Sql("Update MembershipTypes set Name='Quarterly' Where Id=3");
            Sql("Update MembershipTypes set Name='Yearly' Where Id=4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
