using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ToDoList_DAL
{
    public partial class Urgency
    {
        public Urgency()
        {
            Tasks = new HashSet<Task_>();
        }

        [Key]
        public int UrgencyId { get; set; }
        public string? UrgencyName { get; set; }

        public virtual ICollection<Task_> Tasks { get; set; }
    }
}
