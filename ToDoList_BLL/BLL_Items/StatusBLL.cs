using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoList_DAL;
using ToDoList_BLL.Models;

namespace ToDoList_BLL
{
    public class StatusBLL
    {
        private ToDoList_DAL.StatusDAL _DAL;
        private Mapper _StatusMapper;

        public StatusBLL()
        {
            _DAL = new ToDoList_DAL.StatusDAL();
            var configStatus = new MapperConfiguration(cfg => cfg.CreateMap<Status, StatusModel>().ReverseMap());
            _StatusMapper = new Mapper(configStatus);
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
