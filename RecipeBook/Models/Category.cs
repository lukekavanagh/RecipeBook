using System.Collections.Generic;
using Newtonsoft.Json;

namespace RecipeBook.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; } 
    }
}