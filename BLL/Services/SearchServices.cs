using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SearchService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<BookDTO,Book >();
            });
            return new Mapper(config);
        }
        public static List<BookDTO> Search(string keyword)
        {
            var data = DataAccess.SearchData().Search(keyword);
            return GetMapper().Map<List<BookDTO>>(data);
        }

    }
}
