using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class RecipesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RecipesAPI
        public IQueryable<Recipe> GetRecipes()
        {
            return db.Recipes;
        }

        // GET: api/RecipesAPI/5
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult GetRecipe(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // PUT: api/RecipesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipe(int id, Recipe recipe)
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
                db.SaveChanges();
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

        // POST: api/RecipesAPI
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult PostRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipes.Add(recipe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipe.Id }, recipe);
        }

        // DELETE: api/RecipesAPI/5
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult DeleteRecipe(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            db.Recipes.Remove(recipe);
            db.SaveChanges();

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

        [HttpGet]
        private bool RecipeExists(int id)
        {
            return db.Recipes.Count(e => e.Id == id) > 0;
        }

        // GET: api/RecipesAPI/UpVote/5
        [HttpGet]
        public int UpVote(int Id)
        {
            var Recipe = db.Recipes.Single(x => x.Id == Id);
            var points = Recipe.Points;
            Recipe.Points++;
            db.Recipes.AddOrUpdate(Recipe);
            db.SaveChanges();
            return points;
        }
    }
   
}