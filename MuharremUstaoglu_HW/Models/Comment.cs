using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuharremUstaoglu_HW2.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Başlık Alanı 3 ile 10 karakter arasında olmalıdır")]
       [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name = "Detay")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Detay alanı 3 ile 10 karakter arasında olmalıdır")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Detail { get; set; }

        [Display(Name = "Değerlendirme")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int? Rating { get; set; }

        [Display(Name = "Oluşturulma zamanı")]
        public DateTime CreatedDate { get; set; }

        public int BookId { get; set; }

        //[Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Kitap")]
        public Book Book { get; set; }

        public Comment()
        {
            CreatedDate = DateTime.Now;

        }




    }
}
