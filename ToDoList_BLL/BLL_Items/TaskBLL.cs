using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoList_BLL.Models;
using ToDoList_DAL;

namespace ToDoList_BLL
{
    public class TaskBLL
    {
        private ToDoList_DAL.TaskDAL _DAL;
        private Mapper _TaskMapper;
        public TaskBLL()
        {
            _DAL = new ToDoList_DAL.TaskDAL();
            var configTask = new MapperConfiguration(cfg => cfg.CreateMap<Task_, TaskModel>().ReverseMap());
            _TaskMapper = new Mapper(configTask);
        }

        public List<TaskModel> GetTasks()
        {
            List<Task_> tasksFromDB = _DAL.GetTasks();
            List<TaskModel> taskModels = _TaskMapper.Map<List<Task_>, List<TaskModel>>(tasksFromDB);
            return taskModels;
        }

        public IEnumerable<TaskModel> GetTasksPerCategory(int category_id)
        {
            IEnumerable<Task_> tasksFromDB=_DAL.GetTasksPerCategory(category_id);
            IEnumerable<TaskModel> taskModels = _TaskMapper.Map<IEnumerable<Task_>, IEnumerable<TaskModel>>(tasksFromDB);
            return taskModels;
        }

        public async Task<TaskModel> GetTask_(int id)
        {
            Task_ task = await _DAL.GetTask_(id);
            TaskModel taskModel = _TaskMapper.Map<Task_,TaskModel>(task);
            return taskModel;
        }

        public async Task<IAsyncResult> PutTask_(int id, string taskName, string taskDescription, int taskUrgency, int taskStatus)
        {
            return await _DAL.PutTask_(id, taskName, taskDescription, taskUrgency, taskStatus);
        }

        public async Task<Task_> PostTask_(string taskName, string taskDescription, int taskUrgency, int taskStatus, int taskCategory)
        {
            return await _DAL.PostTask_(taskName, taskDescription, taskUrgency,taskStatus, taskCategory);
        }

        public async Task<IAsyncResult> DeleteTask_(int id)
        {
            return _DAL.DeleteTask_(id);
        }
    }
}
