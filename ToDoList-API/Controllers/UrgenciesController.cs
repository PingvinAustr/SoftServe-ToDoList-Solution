using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList_API;
using ToDoList_BLL.Models;
using ToDoList_DAL;

namespace ToDoList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgenciesController : ControllerBase
    {
        private ToDoList_BLL.UrgencyBLL _BLL;

        public UrgenciesController()
        {
            _BLL = new ToDoList_BLL.UrgencyBLL();
        }

        // GET: api/Urgencies
        [HttpGet]
        public async Task<ActionResult<List<UrgencyModel>>> GetUrgencies()
        {
            return _BLL.GetUrgencies();
        }

        // GET: api/Urgencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UrgencyModel>> GetUrgency(int id)
        {
           return await _BLL.GetUrgency(id);
        }

        // DELETE: api/Urgencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrgency(int id)
        {
            await _BLL.DeleteUrgency(id);
            return Ok();
        }
    }
}
