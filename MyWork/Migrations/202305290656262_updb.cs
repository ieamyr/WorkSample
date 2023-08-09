namespace MyWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Couerses", "CouerseName", c => c.String());
            AddColumn("dbo.Couerses", "ActivaDiscount", c => c.Boolean(nullable: false));
            DropColumn("dbo.Couerses", "LinkVideo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Couerses", "LinkVideo", c => c.String());
            DropColumn("dbo.Couerses", "ActivaDiscount");
            DropColumn("dbo.Couerses", "CouerseName");
        }
    }
}
