using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DAL.Interfaces
{
    public interface ITaskRepository
    {
        public List<Task_> GetTasks();

        public List<Task_> GetTasksPerCategory(int category_id);

        public  Task<Task_> GetTask_(int id);

        public  Task<IAsyncResult> PutTask_(int id, string taskName, string taskDescription, int taskUrgency, int taskStatus);

        public  Task<Task_> PostTask_(string taskName, string taskDescription, int taskUrgency, int taskStatus, int taskCategory);

        public  Task<IAsyncResult> DeleteTask_(int id);
    }
}
