using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using RecipeBook.Models;


namespace RecipeBook.Controllers
{
    public class RecipesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public RecipesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        //// GET: Recipes
        //public ActionResult Index()
        //{
        //    return View(db.Recipes.ToList());
        //}

        // GET: api/Recipes
        public IQueryable<Recipe> GetRecipes()
        {
            return db.Recipes;
        }

        // GET: api/Recipes/5
        [ResponseType(typeof (Recipe))]
        public async Task<IHttpActionResult> GetRecipe(int id)
        {
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // PUT: api/Recipes/5
        [ResponseType(typeof (void))]
        public async Task<IHttpActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.Id)
            {
                return BadRequest();
            }

            db.Entry(recipe).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Recipes
        [ResponseType(typeof (Recipe))]
        public async Task<IHttpActionResult> PostRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipes.Add(recipe);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new {id = recipe.Id}, recipe);
        }

        // DELETE: api/Recipes/5
        [ResponseType(typeof (Recipe))]
        public async Task<IHttpActionResult> DeleteRecipe(int id)
        {
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            db.Recipes.Remove(recipe);
            await db.SaveChangesAsync();

            return Ok(recipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeExists(int id)
        {
            return db.Recipes.Count(e => e.Id == id) > 0;
        }

        // GET: api/RecipesAPI/UpVote/5
        [System.Web.Http.HttpGet]
        public int UpVote(int Id)
        {
            var Recipe = db.Recipes.Single(x => x.Id == Id);
            var points = Recipe.Points;
            Recipe.Points++;
            db.Recipes.AddOrUpdate(Recipe);
            db.SaveChanges();
            return points;
        }

        //    public ActionResult Search(string searchBy, string search)
        //    {
        //        if (searchBy == "Recipes")
        //        {
        //            return View(db.Recipes.Where(x => x.Name == search || search == null).ToList());
        //        }
        //        else
        //        {
        //            return View(db.Recipes.Where(x => x.Content.Contains(search) || search == null).ToList());
        //        }

        //    }
        //}
    }
}