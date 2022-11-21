using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoList_BLL.Interfaces;
using ToDoList_BLL.Models;
using ToDoList_DAL;

namespace ToDoList_BLL
{
    public class UrgencyBLL : IUrgency
    {
        private ToDoList_DAL.UrgencyDAL _DAL;
        private readonly IMapper _UrgencyMapper;
        public UrgencyBLL(IMapper mapper)
        {
            _DAL = new ToDoList_DAL.UrgencyDAL();
            _UrgencyMapper = mapper;
        }

        public List<UrgencyModel> GetUrgencies()
        {
            List<Urgency> urgenciesFromDB = _DAL.GetUrgencies();
            List<UrgencyModel> urgencyModels = _UrgencyMapper.Map<List<Urgency>, List<UrgencyModel>>(urgenciesFromDB);
            return urgencyModels;
        }

        public async Task<UrgencyModel> GetUrgency(int id)
        {
            var data = await _DAL.GetUrgency(id);
            UrgencyModel urgencyModel = _UrgencyMapper.Map<Urgency, UrgencyModel>(data);
            return urgencyModel;
        }

        public async Task<IAsyncResult> DeleteUrgency(int id)
        {
            return _DAL.DeleteUrgency(id);
        }
    }
}
