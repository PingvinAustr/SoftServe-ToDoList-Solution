using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_DAL.Interfaces;

namespace ToDoList_DAL
{
    public class CategoryDAL : ICategoryRepository
    {
        public List<Category> GetCategories()
        {
            var db = new ToDoList_DAL.todolistContext();
            return db.Categories.ToList();
        }

        public async Task<Category> GetCategory(int id)
        {
            var _context = new ToDoList_DAL.todolistContext();
            var category = await _context.Categories.FindAsync(id);

            return category;
        }

        public void PostCategory(string categoryName)
        {
                var _context = new ToDoList_DAL.todolistContext();
                Category category = new Category();
                category.CategoryName = categoryName;
                _context.Categories.Add(category);
                _context.SaveChanges();           
        }


        public void PutCategory(int id, string categoryName)
        {
                var _context = new ToDoList_DAL.todolistContext();       
                Category category = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
                category.CategoryName = categoryName;
                _context.Categories.Select(x => x.CategoryId == id ? category : category).ToList();
                _context.SaveChanges();
        }


        public void DeleteCategory(int id)
        {
            var _context = new ToDoList_DAL.todolistContext();
            var category =  _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
