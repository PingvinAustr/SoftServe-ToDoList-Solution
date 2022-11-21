using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_BLL.Models;

namespace ToDoList_BLL.Interfaces
{
    public interface ICategory
    {
        public List<CategoryModel> GetCategories();

        public Task<CategoryModel> GetCategory(int id);

        public void PostCategory(string categoryName);

        public void PutCategory(int id, string categoryName);

        public void DeleteCategory(int id);
    }
}
