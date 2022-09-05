using Microsoft.EntityFrameworkCore;
using Activities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Activities.Models;
using Acitivity.ViewModels;

namespace Acitivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost] // idempotent değildir
        public IActionResult Create(CategoryViewModel category)
        {
            ActivitiesContext context = new ActivitiesContext();
            Category newCategory = new Category();
            newCategory.CategoryName = category.CategoryName;
            context.Categories.Add(newCategory);
            context.SaveChanges();

            //return CreatedAtAction(nameof(GetProductByID), new { id = newProduct.ProductId }, newProduct);

            return Ok();
            //return StatusCode(500, "Ürün eklenemedi");
        }

        [HttpDelete("{categoryID}")]
        public IActionResult Delete(int categoryID)
        {
            ActivitiesContext context = new ActivitiesContext();
            Category category = context.Categories.Find(categoryID);
            context.Categories.Remove(category);
            context.SaveChanges();

            //return NoContent();
            return Ok();
        }

        [HttpPatch("{id}")] // idempotent
        public IActionResult UpdatePartial(int id, CategoryViewModel category)
        {
            ActivitiesContext context = new ActivitiesContext();
            Category originalCategory = context.Categories.Find(id);
            originalCategory.CategoryName = category.CategoryName;
            context.SaveChanges();

            return Ok();
        }


    }
}
