using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_BLL.Models;

namespace ToDoList_BLL.Interfaces
{
    public interface IUrgency
    {
        public List<UrgencyModel> GetUrgencies();

        public Task<UrgencyModel> GetUrgency(int id);

        public Task<IAsyncResult> DeleteUrgency(int id);
    }
}
