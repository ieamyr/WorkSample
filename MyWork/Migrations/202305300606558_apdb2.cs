namespace MyWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apdb2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Couerses", "Cart_CartId", c => c.Int());
            AlterColumn("dbo.Couerses", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Couerses", "Cart_CartId");
            AddForeignKey("dbo.Couerses", "Cart_CartId", "dbo.Carts", "CartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Couerses", "Cart_CartId", "dbo.Carts");
            DropIndex("dbo.Couerses", new[] { "Cart_CartId" });
            DropIndex("dbo.Carts", new[] { "User_Id" });
            AlterColumn("dbo.Couerses", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Couerses", "Cart_CartId");
            DropTable("dbo.Carts");
        }
    }
}
