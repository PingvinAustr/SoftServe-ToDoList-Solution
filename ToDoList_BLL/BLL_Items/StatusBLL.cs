using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoList_DAL;
using ToDoList_BLL.Models;
using ToDoList_BLL.Interfaces;

namespace ToDoList_BLL
{
    public class StatusBLL : IStatus
    {
        private ToDoList_DAL.StatusDAL _DAL;
        private readonly IMapper _StatusMapper;

        public StatusBLL(IMapper mapper)
        {
            _DAL = new ToDoList_DAL.StatusDAL();
            _StatusMapper = mapper;
        }

        public List<StatusModel> GetStatuses()
        {
            List<Status> statusesFromDB=_DAL.GetStatuses();
            List<StatusModel> statusModels = _StatusMapper.Map<List<Status>,List<StatusModel>>(statusesFromDB);
            return statusModels;
        }

        public async Task<StatusModel> GetStatus(int id)
        {
            var data = await _DAL.GetStatus(id);
            StatusModel statusModel = _StatusMapper.Map<Status,StatusModel>(data);
            return statusModel;
        }

        public async Task<IAsyncResult> DeleteStatus(int id)
        {
            return await _DAL.DeleteStatus(id);
        }
    }
}
