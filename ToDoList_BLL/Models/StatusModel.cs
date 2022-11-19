using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_BLL.Models
{
    public class StatusModel
    {
        public int StatusId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}
