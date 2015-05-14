using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string ImageLink { get; set; }
        public int Points { get; set; }
        public virtual ApplicationUser PostedBy { get; set; }
    }
}