namespace MyWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apdb4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Couerses", "Cart_CartId", "dbo.Carts");
            DropForeignKey("dbo.Carts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropIndex("dbo.Couerses", new[] { "Cart_CartId" });
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        CartId = c.String(),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Couerses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Couerses", t => t.Couerses_Id)
                .Index(t => t.Couerses_Id);
            
            DropColumn("dbo.Couerses", "Cart_CartId");
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartId);
            
            AddColumn("dbo.Couerses", "Cart_CartId", c => c.Int());
            DropForeignKey("dbo.CartItems", "Couerses_Id", "dbo.Couerses");
            DropIndex("dbo.CartItems", new[] { "Couerses_Id" });
            DropTable("dbo.CartItems");
            CreateIndex("dbo.Couerses", "Cart_CartId");
            CreateIndex("dbo.Carts", "UserId");
            AddForeignKey("dbo.Carts", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Couerses", "Cart_CartId", "dbo.Carts", "CartId");
        }
    }
}
