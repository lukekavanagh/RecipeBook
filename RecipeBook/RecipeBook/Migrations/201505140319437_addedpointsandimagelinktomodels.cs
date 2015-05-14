namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpointsandimagelinktomodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImageLink", c => c.String());
            AddColumn("dbo.Recipes", "Points", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Points");
            DropColumn("dbo.Categories", "ImageLink");
        }
    }
}
