using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList_API;
using ToDoList_DAL;
using ToDoList_BLL;
using ToDoList_BLL.Models;

namespace ToDoList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private ToDoList_BLL.CategoryBLL _BLL;

        public CategoriesController()
        {
            _BLL = new ToDoList_BLL.CategoryBLL();
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetCategories()
        {
            return _BLL.GetCategories();
        }

        

        
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategory(int id)
        {
            var category = _BLL.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


        // PUT: api/Categories/5
        [HttpPut]
        public void PutCategory(int id, [FromForm]string categoryName)
        {
            _BLL.PutCategory(id, categoryName);
        }

        // POST: api/Categories
        [HttpPost]
        public void PostCategory([FromForm] string categoryName)
        {
            _BLL.PostCategory(categoryName);
        }


        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _BLL.DeleteCategory(id);
        }
        
    }
}
