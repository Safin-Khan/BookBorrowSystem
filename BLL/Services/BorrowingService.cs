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
    public class BorrowingService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Borrowing, BorrowingDTO>();
                cfg.CreateMap<BorrowingDTO, Borrowing>();

            });
            return new Mapper(config);
        }
        public static bool Create(BorrowingDTO obj)
        {
            var data = GetMapper().Map<Borrowing>(obj);
            return DataAccess.BorrowingData().Create(data);
        }
        public static List<BorrowingDTO> Get()
        {
            var data = DataAccess.BorrowingData().Get();
            return GetMapper().Map<List<BorrowingDTO>>(data);
        }
        public static BorrowingDTO Get(int id)
        {
            var data = DataAccess.BorrowingData().Get(id);
            return GetMapper().Map<BorrowingDTO>(data);
        }
        public static List<BorrowingDTO> GetbyUid(int id)
        {
            var data = DataAccess.UidData().GetbyUid(id);
            return GetMapper().Map<List<BorrowingDTO>>(data).ToList();
        }
        public static bool Update(BorrowingDTO obj)
        {
            var data = GetMapper().Map<Borrowing>(obj);
            return DataAccess.BorrowingData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.BorrowingData().Delete(id);
        }
    }
}
