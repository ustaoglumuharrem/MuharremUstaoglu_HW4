using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuharremUstaoglu_HW2.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(512, MinimumLength = 3, ErrorMessage = "Kitap adı en az 3 karakterden oluşmalıdır.")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Kitap Adı")]
        public string Title { get; set; } // nvarchar(512), not nullable
        [Display(Name = "Sayfa sayısı")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int? PageCount { get; set; }

        [Display(Name = "Yazar")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Authors { get; set; }
        [Display(Name = "Tanım")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Description { get; set; }
        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Bu alan zorunludur. Eğer kitap ücretsizse 0 olarak giriniz.")]
        public Decimal Price { get; set; }

        [Display(Name = "Basım yılı")]
       [Required(ErrorMessage = "Bu alan zorunludur.")]
        public DateTime PressYear { get; set; }


        [Display(Name = "Stok sayısı")]
        public int StockCount { get; set; }



        public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        //[Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Kategori")]
        public Category Category { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public Book()
        {
            CreatedDate = DateTime.Now;

        }


    }
}
