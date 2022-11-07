﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList_API;
using ToDoList_DAL;

namespace ToDoList_API.Controllers
{
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
            Console.WriteLine("1");
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Task_/{category_id}
        [HttpGet("{category_id:int}")]
        public ActionResult<IEnumerable<Task_>> GetTasksPerCategory(int category_id)
        {
            Console.WriteLine("2");
            List<Task_> tasks = new List<Task_>();
            tasks=_context.Tasks.Where(task=>task.TaskCategory==category_id).ToList();
            return  tasks;
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask_(int id, Task_ task_)
        {
            if (id != task_.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(task_).State = EntityState.Modified;

            try
            {
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
        public async Task<ActionResult<Task_>> PostTask_(Task_ task_)
        {
            _context.Tasks.Add(task_);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask_", new { id = task_.TaskId }, task_);
        }

        // DELETE: api/Task_/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask_(int id)
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

        private bool Task_Exists(int id)
        {
            return _context.Tasks.Any(e => e.TaskId == id);
        }
    }
}
