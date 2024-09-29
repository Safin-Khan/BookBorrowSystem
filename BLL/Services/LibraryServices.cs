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
    public class LibraryServices
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Library, LibraryDTO>();
                cfg.CreateMap<LibraryDTO, Library>();

            });
            return new Mapper(config);
        }
        public static bool Create(LibraryDTO obj)
        {
            var data = GetMapper().Map<Library>(obj);
            return DataAccess.LibraryData().Create(data);
        }
        public static List<LibraryDTO> Get()
        {
            var data = DataAccess.LibraryData().Get();
            return GetMapper().Map<List<LibraryDTO>>(data);
        }
        public static LibraryDTO Get(int id)
        {
            var data = DataAccess.LibraryData().Get(id);
            return GetMapper().Map<LibraryDTO>(data);
        }
        public static bool Update(LibraryDTO obj)
        {
            var data = GetMapper().Map<Library>(obj);
            return DataAccess.LibraryData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.LibraryData().Delete(id);
        }
    }
}
