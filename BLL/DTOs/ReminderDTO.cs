using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReminderDTO
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Borrowing")]
        public int BorrowingID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public DateTime ReminderDate { get; set; }

        public string Message { get; set; }
    }
}
