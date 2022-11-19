using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ToDoList_DAL
{
    public partial class Status
    {
        public Status()
        {
            Tasks = new HashSet<Task_>();
        }

        [Key]
        public int StatusId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<Task_> Tasks { get; set; }
    }
}
