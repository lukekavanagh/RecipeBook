using RecipeBook.Models;

namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
                c => c.CategoryName,
                new Category { CategoryName = "Dinner" },
                new Category { CategoryName = "Drinks" },
                new Category { CategoryName = "Breakfast" }
                );
            
            context.Recipes.AddOrUpdate(
                r => r.Title,
                new Recipe { Title = "Lemon Honey Chicken", CategoryName = "Dinner", Points = 0, Content = "Deep fry chicken strips lather in sauce done.", ImageLink = ""},
                new Recipe { Title = "Gangsta Beef", CategoryName = "Dinner", Points = 0, Content = "BBQ Beef with yo chainz on!", ImageLink = ""},
                new Recipe { Title = "Coffee with butter", CategoryName = "Drinks", Points = 0, Content = "Get all crazy and with your blender. Pray!", ImageLink = ""},
                new Recipe { Title = "Blueberry Smoothie", CategoryName = "Breakfast", Points = 0, Content = "Berry it up", ImageLink = ""}
                );
        }
    }
}
