using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarınagi.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Lütfen isim giriniz")]
        [Display(Name = "İsmi")]
        public string Name { get; set;}


        [Display(Name = "Hayvanın Cinsi")]
        [Required]
        public int AnimalTypeId { get; set; }
        [ForeignKey("AnimalTypeId")]
        public virtual AnimalTypes AnimalTypes { get; set; }


        [Display(Name = "Cinsiyet")]
        [Required]
        public int GenderTypeId { get; set; }
        [ForeignKey("GenderTypeId")]
        public virtual GenderType GenderType { get; set; }

        [Required(ErrorMessage = "Lütfen yaşını giriniz")]
        [Display(Name = "Yaş")]
        public string Age { get; set; }

        [Display(Name = "Sahipli mi")]
        [Required]
        public int OwnedTypeId { get; set; }
        [ForeignKey("OwnedTypeId")]
        public virtual OwnedType OwnedType { get; set; }

        [Required(ErrorMessage = "Lütfen rengini giriniz")]
        [Display(Name = "Renk")]
        public string Color { get; set; }

    }
}
