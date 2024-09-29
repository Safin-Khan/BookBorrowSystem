using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BorrowBookDTO : BorrowingDTO
    {
        public List<BookDTO> Products { get; set; }
        public BorrowBookDTO()
        {
            Products = new List<BookDTO>();
        }
    }
}
