namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Recipes", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.Recipes", "CategoryName", c => c.String());
            AlterColumn("dbo.Recipes", "Category_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "Category_Id");
            AddForeignKey("dbo.Recipes", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Recipes", new[] { "Category_Id" });
            AlterColumn("dbo.Recipes", "Category_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Recipes", "CategoryName");
            RenameColumn(table: "dbo.Recipes", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.Recipes", "CategoryId");
            AddForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
