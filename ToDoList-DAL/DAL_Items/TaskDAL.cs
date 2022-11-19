using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DAL
{
    public class TaskDAL
    {
        public List<Task_> GetTasks()
        {
            var _context = new ToDoList_DAL.todolistContext();
            return _context.Tasks.ToList();
        }

        public IEnumerable<Task_> GetTasksPerCategory(int category_id)
        {
            var _context = new ToDoList_DAL.todolistContext();
            List<Task_> tasks = new List<Task_>();
            tasks = _context.Tasks.Where(task => task.TaskCategory == category_id).ToList();
            return tasks;
        }

        public async Task<Task_> GetTask_(int id)
        {
            var _context = new ToDoList_DAL.todolistContext();
            var task_ = await _context.Tasks.FindAsync(id);
            return task_;
        }

        public async Task<IAsyncResult> PutTask_(int id, string taskName, string taskDescription, int taskUrgency, int taskStatus)
        {
                var _context = new ToDoList_DAL.todolistContext();
                Task_ item = _context.Tasks.Where(x => x.TaskId == id).FirstOrDefault();
                item.TaskName = taskName;
                item.TaskDescription = taskDescription;
                item.TaskStatus = taskStatus;
                item.TaskUrgency = taskUrgency;
                _context.Tasks.Select(x => x.TaskId == id ? item : item).ToList();
                await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Task_> PostTask_(string taskName,string taskDescription, int taskUrgency, int taskStatus, int taskCategory)
        {
            var _context = new ToDoList_DAL.todolistContext();
            Task_ task_ = new Task_();
            task_.TaskName = taskName;
            task_.TaskDescription = taskDescription;
            task_.TaskStatus = taskStatus;
            task_.TaskUrgency = taskUrgency;
            task_.TaskCategory = taskCategory;

            _context.Tasks.Add(task_);
            await _context.SaveChangesAsync();
            return task_;
        }

        public async Task<IAsyncResult> DeleteTask_(int id)
        {
            var _context = new ToDoList_DAL.todolistContext();
            var task_ = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task_);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
