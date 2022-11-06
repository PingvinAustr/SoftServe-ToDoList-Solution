using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ToDoList_DAL
{
    public partial class Task_
    {
        [Key]
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public int? TaskUrgency { get; set; }
        public int? TaskCategory { get; set; }
        public int? TaskStatus { get; set; }

        public virtual Category? TaskCategoryNavigation { get; set; }
        public virtual Status? TaskStatusNavigation { get; set; }
        public virtual Urgency? TaskUrgencyNavigation { get; set; }
    }
}
