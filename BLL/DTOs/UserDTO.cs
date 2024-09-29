using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
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

        public DateTime RegistrationDate { get; set; }

        public bool IsAdmin { get; set; }
    }
}
