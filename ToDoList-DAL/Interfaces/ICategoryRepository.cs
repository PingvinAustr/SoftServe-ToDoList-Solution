using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DAL.Interfaces
{
    public  interface ICategoryRepository
    {
        public List<Category> GetCategories();


        public Task<Category> GetCategory(int id);

        public void PostCategory(string categoryName);


        public void PutCategory(int id, string categoryName);


        public void DeleteCategory(int id);
    }
}
