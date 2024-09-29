using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class User
    {
       

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
      
        public string Username { get; set; }

        [Required]
        [StringLength(8)]
      
        public string Password { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string FullName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RegistrationDate { get; set; }


        public bool IsAdmin { get; set; }

        // Navigation Properties
        //public virtual BorrowingLimit BorrowingLimit { get; set; }
        public virtual ICollection<Borrowing> Borrowings { get; set; }
        

        public User()
        {
            Borrowings = new List<Borrowing>();
            
        }
    }
}
