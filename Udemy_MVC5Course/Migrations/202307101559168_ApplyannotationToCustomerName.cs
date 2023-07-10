﻿namespace Udemy_MVC5Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyannotationToCustomerName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "C_Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "C_Name", c => c.String());
        }
    }
}
