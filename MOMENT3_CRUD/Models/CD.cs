using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOMENT3_CRUD.Models
{
    public class CD
    {
        [Key]
        public int CdId { get; set; } //PK value

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double Length { get; set; }

        [Required]
        public string Label { get; set; }


        [Required]
        public int GenresId { get; set; } //FK

        public virtual Genres Genres { get; set; } //Takes in Genres
    }
}
