using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList_API;
using ToDoList_BLL.Interfaces;
using ToDoList_BLL.Models;

namespace ToDoList_API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class Task_Controller : ControllerBase
    {
        private ToDoList_BLL.TaskBLL _BLL;
        private readonly IMapper _mapper;
        private readonly ITask _task;

        public Task_Controller(IMapper mapper, ITask task)
        {
            _mapper = mapper;
            _task = task;
            _BLL = new ToDoList_BLL.TaskBLL(mapper);
        }


        // GET: api/Task_
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetTasks()
        {
            //return _BLL.GetTasks();
            return _task.GetTasks();
        }

        // GET: api/Task_/{category_id}
        [HttpGet("{category_id:int}")]
        public ActionResult<List<TaskModel>> GetTasksPerCategory(int category_id)
        {
            //return Ok(_BLL.GetTasksPerCategory(category_id));
            return Ok(_task.GetTasksPerCategory(category_id));
        }

        // GET: api/Task_/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTask_(int id)
        {
            //return await _BLL.GetTask_(id);
            return await _task.GetTask_(id);
        }

        // PUT: api/Task_/5
        [HttpPut]
        public async Task<IActionResult> PutTask_(int id, [FromForm] string taskName, [FromForm] string taskDescription, [FromForm] int taskUrgency, [FromForm] int taskStatus)
        {
            return (IActionResult)await _task.PutTask_(id, taskName, taskDescription, taskUrgency, taskStatus);
        }

        // POST: api/Task_
        [HttpPost]
        public async Task<TaskModel> PostTask_([FromForm]string taskName, [FromForm] string taskDescription, [FromForm] int taskUrgency, [FromForm] int taskStatus, [FromForm] int taskCategory)
        {
            return await _task.PostTask_(taskName, taskDescription, taskUrgency,taskStatus,taskCategory);
        }

        // DELETE: api/Task_/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask_([FromForm] int id)
        {
            return (IActionResult)_task.DeleteTask_(id);
        }
    }
}
