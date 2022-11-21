using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_BLL.Models;

namespace ToDoList_BLL.Interfaces
{
    public interface IStatus
    {
        public List<StatusModel> GetStatuses();

        public Task<StatusModel> GetStatus(int id);

        public Task<IAsyncResult> DeleteStatus(int id);
    }
}
