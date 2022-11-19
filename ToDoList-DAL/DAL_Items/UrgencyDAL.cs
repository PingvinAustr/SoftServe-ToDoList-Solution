using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DAL
{
    public class UrgencyDAL
    {
        public List<Urgency> GetUrgencies()
        {
            var _context = new ToDoList_DAL.todolistContext();
            return _context.Urgencies.ToList();
        }

        public async Task<Urgency> GetUrgency(int id)
        {
            var _context = new ToDoList_DAL.todolistContext();
            var urgency = await _context.Urgencies.FindAsync(id);
            return urgency;
        }

        public async Task<IAsyncResult> DeleteUrgency(int id)
        {
            var _context = new ToDoList_DAL.todolistContext();
            var urgency = await _context.Urgencies.FindAsync(id);
            _context.Urgencies.Remove(urgency);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
