using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_BLL.Models
{
    public class UrgencyModel
    {
        public int UrgencyId { get; set; }
        public string? UrgencyName { get; set; }

        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}
