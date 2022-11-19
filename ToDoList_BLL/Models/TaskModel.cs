using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_BLL.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public int? TaskUrgency { get; set; }
        public int? TaskCategory { get; set; }
        public int? TaskStatus { get; set; }

        public virtual CategoryModel? TaskCategoryNavigation { get; set; }
        public virtual StatusModel? TaskStatusNavigation { get; set; }
        public virtual UrgencyModel? TaskUrgencyNavigation { get; set; }
    }
}
