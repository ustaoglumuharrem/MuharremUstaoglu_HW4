using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuharremUstaoglu_HW2.ViewModel
{
    public class SearchViewModel
    {
        [Display(Name = "Arama Metni")]
        public string SearchText { get; set; }
        [Display(Name = "Açıklamalarda Ara")]
        public bool SearchInDescription { get; set; }
        [Display(Name = "Kategori Seçimi")]
        public int? CategoryId { get; set; }
        [Display(Name = "Minimum fiyat")]
        public int? MinPrice { get; set; }
        [Display(Name = "Maximum fiyat")]
        public int? MaxPrice { get; set; }

        public List<Models.Book> Results { get; set; }
    }
}
