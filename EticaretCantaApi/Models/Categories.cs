using System.ComponentModel.DataAnnotations;

namespace EticaretCantaApi.Models
{
    public class Categories
    {
        [Key]
        public int Category_Id { get; set; }
        [Required(ErrorMessage = "Kategori Adı Boş Bırakılamaz!")]
        [Display(Name = "Kategori Adı")]
        public string Category_Name { get; set; }=string.Empty;
        public ICollection<Sub_Category>? Sub_Categories { get; set; } = null!;
        public ICollection<Products>? Products { get; set; } = null!;
    }
}
