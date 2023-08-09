namespace MyWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apdb3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Carts", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Carts", name: "IX_User_Id", newName: "IX_UserId");
            AddColumn("dbo.Carts", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "Quantity");
            DropColumn("dbo.Carts", "ProductId");
            RenameIndex(table: "dbo.Carts", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Carts", name: "UserId", newName: "User_Id");
        }
    }
}
