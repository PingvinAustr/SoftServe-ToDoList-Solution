using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_DAL;
using AutoMapper;
using ToDoList_BLL.Models;

namespace ToDoList_BLL
{
    public class CategoryBLL
    {
        private ToDoList_DAL.CategoryDAL _DAL;
        private Mapper _CategoryMapper;
        public CategoryBLL()
        {
            _DAL=new ToDoList_DAL.CategoryDAL();
            var configCategory = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryModel>().ReverseMap());
            _CategoryMapper = new Mapper(configCategory);
        }
        public List<CategoryModel> GetCategories()
        {
            List<Category> categoriesFromDB = _DAL.GetCategories();
            List<CategoryModel> categoryModels = _CategoryMapper.Map<List<Category>, List<CategoryModel>>(categoriesFromDB);
            return categoryModels;
        }

        public async Task<CategoryModel> GetCategory(int id)
        {
            var data = await _DAL.GetCategory(id);
            CategoryModel categoryModel = _CategoryMapper.Map<Category, CategoryModel>(data);
            return categoryModel;
        }

        public void PostCategory(string categoryName)
        {
            _DAL.PostCategory(categoryName);
        }

        public void PutCategory(int id, string categoryName)
        {
            _DAL.PutCategory(id, categoryName);
        }

        public void DeleteCategory(int id)
        {
            _DAL.DeleteCategory(id);
        }
    }
}
