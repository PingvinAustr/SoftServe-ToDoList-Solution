using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList_API;
using ToDoList_DAL;

namespace ToDoList_API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class Task_Controller : ControllerBase
    {
        private readonly todolistContext _context;

        public Task_Controller(todolistContext context)
        {
            _context = context;
        }

        // GET: api/Task_
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task_>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Task_/{category_id}
        [HttpGet("{category_id:int}")]
        public ActionResult<IEnumerable<Task_>> GetTasksPerCategory(int category_id)
        {
            List<Task_> tasks = new List<Task_>();
            tasks = _context.Tasks.Where(task => task.TaskCategory == category_id).ToList();
            return tasks;
        }

        // GET: api/Task_/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Task_>> GetTask_(int id)
        {
            var task_ = await _context.Tasks.FindAsync(id);

            if (task_ == null)
            {
                return NotFound();
            }

            return task_;
        }

        // PUT: api/Task_/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        // public async Task<IActionResult> PutTask_(int id, string taskName, string taskDescription, int taskUrgency, int taskStatus)
        [HttpPut]
        public async Task<IActionResult> PutTask_(int id, [FromForm] string taskName, [FromForm] string taskDescription, [FromForm] int taskUrgency, [FromForm] int taskStatus)
        {

            try
            {
                Task_ item = _context.Tasks.Where(x => x.TaskId == id).FirstOrDefault();
                item.TaskName = taskName;
                item.TaskDescription = taskDescription;
                item.TaskStatus = taskStatus;
                item.TaskUrgency = taskUrgency;
                _context.Tasks.Select(x => x.TaskId == id ? item : item).ToList();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Task_Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return NoContent();
        }

        // POST: api/Task_
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Task_>> PostTask_([FromForm]string taskName, [FromForm] string taskDescription, [FromForm] int taskUrgency, [FromForm] int taskStatus, [FromForm] int taskCategory)
        {
            Task_ task_ = new Task_();
            task_.TaskName= taskName;
            task_.TaskDescription= taskDescription;
            task_.TaskStatus= taskStatus;
            task_.TaskUrgency= taskUrgency;
            task_.TaskCategory= taskCategory;

            _context.Tasks.Add(task_);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask_", new { id = task_.TaskId }, task_);
        }

        // DELETE: api/Task_/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask_([FromForm] int id)
        {
            var task_ = await _context.Tasks.FindAsync(id);
            if (task_ == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task_);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        /*
        [HttpDelete("id")]
        public void DeleteTask_([FromForm] int id)
        {
            Console.WriteLine("delete["+id+"]");
        }
        */

        private bool Task_Exists(int id)
        {
            return _context.Tasks.Any(e => e.TaskId == id);
        }
    }
}
