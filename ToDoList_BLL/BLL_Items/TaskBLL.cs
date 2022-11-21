using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoList_BLL.Interfaces;
using ToDoList_BLL.Models;
using ToDoList_DAL;

namespace ToDoList_BLL
{
    public class TaskBLL : ITask
    {
        private ToDoList_DAL.TaskDAL _DAL;
        private readonly IMapper _TaskMapper;
        public TaskBLL(IMapper mapper)
        {
            _DAL = new ToDoList_DAL.TaskDAL();
            _TaskMapper = mapper;
        }

        public List<TaskModel> GetTasks()
        {
            List<Task_> tasksFromDB = _DAL.GetTasks();
            List<TaskModel> taskModels = _TaskMapper.Map<List<Task_>, List<TaskModel>>(tasksFromDB);
            return taskModels;
        }

        public List<TaskModel> GetTasksPerCategory(int category_id)
        {
            List<Task_> tasksFromDB=_DAL.GetTasksPerCategory(category_id);
            List<TaskModel> taskModels = _TaskMapper.Map<List<Task_>, List<TaskModel>>(tasksFromDB);
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

        public async Task<TaskModel> PostTask_(string taskName, string taskDescription, int taskUrgency, int taskStatus, int taskCategory)
        {
            Task_ task = await _DAL.PostTask_(taskName, taskDescription, taskUrgency,taskStatus, taskCategory);
            TaskModel taskModel =_TaskMapper.Map<Task_,TaskModel>(task);
            return taskModel;

        }

        public async Task<IAsyncResult> DeleteTask_(int id)
        {
            return _DAL.DeleteTask_(id);
        }
    }
}
