using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList_API;
using ToDoList_BLL.Interfaces;
using ToDoList_BLL.Models;
using ToDoList_DAL;

namespace ToDoList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private ToDoList_BLL.StatusBLL _BLL;
        private readonly IStatus _status;
        private readonly IMapper _mapper;
        public StatusController(IMapper mapper, IStatus status)
        {
            _mapper = mapper;
            _status = status;
            _BLL = new ToDoList_BLL.StatusBLL(mapper);
        }


        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<List<StatusModel>>> GetStatuses()
        {
            //return _BLL.GetStatuses();
            return _status.GetStatuses();
        }


        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusModel>> GetStatus(int id)
        {
            //var status = _BLL.GetStatus(id);
            var status = _status.GetStatus(id);

            if (status == null)
            {
                return NotFound();
            }

            return await status;
        }


        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            //await _BLL.DeleteStatus(id);
            await _status.DeleteStatus(id);
            return Ok();
        }

    }
}
