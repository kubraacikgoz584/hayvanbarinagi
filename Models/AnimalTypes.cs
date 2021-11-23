using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarınagi.Models
{
    public class AnimalTypes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Animal Type")]
        public string AnimalType { get; set; }
    }
}
