using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarınagi.Models
{
    public class GenderType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cinsiyet")]
        public string Gender { get; set; }
    }
}
