using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EticaretCanta.Models
{
    public class Pictures
    {
      [Key]
      public int  Picture_Id { get; set; }
      public string Name { get; set; } = string.Empty;

      public int ? Product_Id { get; set; } 
      public Products ? Products { get; set; }

     [NotMapped]
     public IFormFile? ImageUpload { get; set; }

    }
}
