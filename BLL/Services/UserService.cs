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
    public class UserService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();

            });
            return new Mapper(config);
        }
        public static bool Create(UserDTO obj)
        {
            obj.RegistrationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            
            var data = GetMapper().Map<User>(obj);
            return DataAccess.UserData().Create(data);
        }
        public static List<UserDTO> Get()
        {
            var data = DataAccess.UserData().Get();
            return GetMapper().Map<List<UserDTO>>(data);
        }
        public static UserDTO Get(int id)
        {
            var data = DataAccess.UserData().Get(id);
            return GetMapper().Map<UserDTO>(data);
        }
        public static bool Update(UserDTO obj)
        {
            var data = GetMapper().Map<User>(obj);
            return DataAccess.UserData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.UserData().Delete(id);
        }
    }
}
