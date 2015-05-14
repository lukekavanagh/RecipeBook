using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBook.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageLink { get; set; }
        public virtual ApplicationUser PostedBy { get; set; }
        public virtual int CategoryId { get; set; }
    }
}