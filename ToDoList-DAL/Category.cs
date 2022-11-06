using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ToDoList_DAL
{
    public partial class Category
    {
        public Category()
        {
            Tasks = new HashSet<Task_>();
        }

        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Task_> Tasks { get; set; }
    }
}
