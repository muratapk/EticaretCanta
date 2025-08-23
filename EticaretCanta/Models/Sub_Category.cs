using System.ComponentModel.DataAnnotations;

namespace EticaretCanta.Models
{
    public class Sub_Category
    {
        [Key]
        public  int Sub_Category_Id { get; set; }

        [Required(ErrorMessage = "Alt Kategori Adı Boş Bırakılamaz!")]
        [Display(Name = "Alt Kategori Adı")]
        public string Sub_Category_Name { get; set; } = string.Empty;

        [Display(Name = "Kategori Adı")]
        public int ? Category_Id { get; set; }

        [Display(Name = "Kategori Adı")]
        public Categories? Category { get; set; } = null!;
        public ICollection<Products>? Products { get; set; } = null!;
    }
}
