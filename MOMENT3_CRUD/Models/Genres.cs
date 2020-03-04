using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOMENT3_CRUD.Models
{
    public class Genres
    {
       [Key]
        public int GenresId { get; set; }

        [Required]
        public string Genre_Name { get; set; }

        public ICollection<CD> CDs { get; set; }
    }
}
