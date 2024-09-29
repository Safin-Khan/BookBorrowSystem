using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.TableModels
{
    public class Borrowing
    {
     
        [Key]
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

        // Navigation Property 
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }

        // Constructor to initialize collections
        public Borrowing()
        {
            Reminders = new List<Reminder>();
            Books = new List<Book>();
        }
    }
}

