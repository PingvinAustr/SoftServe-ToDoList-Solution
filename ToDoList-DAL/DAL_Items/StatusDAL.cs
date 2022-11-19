using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DAL
{
    public class StatusDAL
    {
        public List<Status> GetStatuses()
        {
            var _context = new ToDoList_DAL.todolistContext();
            return _context.Statuses.ToList();
        }

        public async Task<Status> GetStatus(int id)
        {
            var _context = new ToDoList_DAL.todolistContext();
            var status = await _context.Statuses.FindAsync(id);
            return status;
        }

        public async Task<IAsyncResult> DeleteStatus(int id)
        {
            var _context = new ToDoList_DAL.todolistContext();
            var status = await _context.Statuses.FindAsync(id);
            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
