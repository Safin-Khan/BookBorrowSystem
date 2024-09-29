using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LibraryDTO
    {

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string SystemName { get; set; }

        [Required]
        public string APIKey { get; set; }

    }
}
