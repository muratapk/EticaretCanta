using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace EticaretCanta.Models
{
    public class Products
    {
        [Key]
       public int Product_Id { get;set;     }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Color { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;

        public int Stock { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Featured { get; set; }

        public string Comment { get; set; } = string.Empty;

        
        // Navigation property for the sub-category
        public int Sub_Category_Id { get;set; }
        public Sub_Category? Sub_Category { get; set; } = null!;

        // Navigation property for the category
        public int Category_Id { get; set; }
        public Categories? Category { get; set; } = null!;
        public ICollection<Pictures>? Pictures { get; set; }

    }
}
