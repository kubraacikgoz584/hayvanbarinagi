using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarınagi.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Column(TypeName = "Varchar(20)")]  
        public string Kullanici { get; set; }

        [Display(Name = "Şifresi")]
        [Column(TypeName = "Varchar(10)")]
        public string Sifre { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "email required")]
        [EmailAddress(ErrorMessage ="Enter correct email")] 
        public string email { get; set; }

        [MaxLength(1)]
        public string userType { get; set; }

        public Boolean isActive { get; set; }
         
    }
}
