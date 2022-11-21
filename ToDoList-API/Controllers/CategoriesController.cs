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
using AutoMapper;
using ToDoList_BLL.Interfaces;

namespace ToDoList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private ToDoList_BLL.CategoryBLL _BLL;
        private readonly IMapper _mapper;
        private readonly ICategory _category;
        public CategoriesController(IMapper mapper, ICategory category)
        {
            _category = category;
            _mapper = mapper;
            _BLL = new ToDoList_BLL.CategoryBLL(mapper);
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetCategories()
        {
            return _category.GetCategories();
        }

        

        
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategory(int id)
        {
            var category = _category.GetCategory(id);
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
            _category.PutCategory(id, categoryName);
        }

        // POST: api/Categories
        [HttpPost]
        public void PostCategory([FromForm] string categoryName)
        {
            _category.PostCategory(categoryName);
        }


        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _category.DeleteCategory(id);
        }
        
    }
}
