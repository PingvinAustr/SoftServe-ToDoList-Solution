using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_BLL.Models;

namespace ToDoList_BLL.Interfaces
{
    public interface ITask
    {
        public List<TaskModel> GetTasks();

        public List<TaskModel> GetTasksPerCategory(int category_id);

        public Task<TaskModel> GetTask_(int id);

        public Task<IAsyncResult> PutTask_(int id, string taskName, string taskDescription, int taskUrgency, int taskStatus);

        public Task<TaskModel> PostTask_(string taskName, string taskDescription, int taskUrgency, int taskStatus, int taskCategory);

        public Task<IAsyncResult> DeleteTask_(int id);
    }
}
