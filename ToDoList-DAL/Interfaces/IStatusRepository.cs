using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DAL.Interfaces
{
    public interface IStatusRepository
    {
        public List<Status> GetStatuses();

        public Task<Status> GetStatus(int id);

        public Task<IAsyncResult> DeleteStatus(int id);
    }
}
