using RecipeBook.Models;

namespace RecipeBook.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipeBook.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RecipeBook.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Categories.AddOrUpdate(
                c => c.Name,
                new Category { Name = "Breakfast", ImageLink = "" },
                new Category { Name = "Lunch", ImageLink = "" },
                new Category { Name = "Dinner", ImageLink = "" },
                new Category { Name = "Drinks", ImageLink = "" },
                new Category { Name = "Desserts", ImageLink = "" },
                new Category { Name = "Gangsta Class", ImageLink = "" }
            );

            context.Recipes.AddOrUpdate(
                r => r.Name,
                new Recipe { Name = "Falafel", Content = "", ImageLink = "", Points = 0 },
                new Recipe { Name = "Cow Pie", Content = "", ImageLink = "", Points = 0 },
                new Recipe { Name = "Sausage Medeley", Content = "", ImageLink = "", Points = 0 },
                new Recipe { Name = "Cornflake Clusters", Content = "", ImageLink = "", Points = 0 },
                new Recipe { Name = "Super Cow Omlette", Content = "", ImageLink = "", Points = 0 },
                new Recipe { Name = "Buttered Coffee", Content = "", ImageLink = "", Points = 0 },
                new Recipe { Name = "Milk Surprise", Content = "", ImageLink = "", Points = 0 },
                new Recipe { Name = "Udderly Delicious Flan", Content = "", ImageLink = "", Points = 0 },
                new Recipe { Name = "Ultimate Lamb Fry-up", Content = "", ImageLink = "", Points = 0 },
                new Recipe { Name = "The Horns of a Dilemma Special", Content = "", ImageLink = "", Points = 0 },
                new Recipe { Name = "Baked Spleen", Content = "", ImageLink = "", Points = 0 }
            );
        }
    }
}
