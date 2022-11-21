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
    public class UrgenciesController : ControllerBase
    {
        private ToDoList_BLL.UrgencyBLL _BLL;
        private readonly IMapper _mapper;
        private readonly IUrgency _urgency;

        public UrgenciesController(IMapper mapper, IUrgency urgency)
        {
            _mapper = mapper;
            _urgency = urgency;
            _BLL = new ToDoList_BLL.UrgencyBLL(mapper);
        }

        // GET: api/Urgencies
        [HttpGet]
        public async Task<ActionResult<List<UrgencyModel>>> GetUrgencies()
        {
            return _urgency.GetUrgencies();
        }

        // GET: api/Urgencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UrgencyModel>> GetUrgency(int id)
        {
           return await _urgency.GetUrgency(id);
        }

        // DELETE: api/Urgencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrgency(int id)
        {
            await _urgency.DeleteUrgency(id);
            return Ok();
        }
    }
}
