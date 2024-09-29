using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookDTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        
        public string Author { get; set; }


        [StringLength(20)]
        public string ISBN { get; set; }



        public DateTime PublishDate { get; set; }

        public int AvailableCopies { get; set; }
        [ForeignKey("Borrowing")]
        public int BId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
