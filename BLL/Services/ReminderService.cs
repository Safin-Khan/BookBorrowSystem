using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReminderService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Reminder, ReminderDTO>();
                cfg.CreateMap<ReminderDTO, Reminder>();

            });
            return new Mapper(config);
        }
        public static bool Create(ReminderDTO obj)
        {
            var data = GetMapper().Map<Reminder>(obj);
            return DataAccess.ReminderData().Create(data);
        }
        public static List<ReminderDTO> Get()
        {
            var data = DataAccess.ReminderData().Get();
            return GetMapper().Map<List<ReminderDTO>>(data);
        }
        public static ReminderDTO Get(int id)
        {
            var data = DataAccess.ReminderData().Get(id);
            return GetMapper().Map<ReminderDTO>(data);
        }
        public static bool Update(ReminderDTO obj)
        {
            var data = GetMapper().Map<Reminder>(obj);
            return DataAccess.ReminderData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.ReminderData().Delete(id);
        }

    }
}
