using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBook.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Recipe> Recipes { get; set; }
    }
}