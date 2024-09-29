using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BorrowingDTO
    {
        public int ID { get; set; }

        // Foreign Key and Relationship with User
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        // Foreign Key and Relationship with Book
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }

        // Borrowing Details
        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }
        public bool Reminder { get; set; }
    }
}

