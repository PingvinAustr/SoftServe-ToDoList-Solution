using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_BLL.Models;
using ToDoList_DAL;

namespace ToDoList_BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Urgency, UrgencyModel>().ReverseMap();
            CreateMap<Status, StatusModel>().ReverseMap();
            CreateMap<Task_, TaskModel>().ReverseMap();
        }
    }
}
