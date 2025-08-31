namespace EticaretCanta.Models
{
    public class ProductWithPictures
    {
        public Products Product { get; set; } = null;
        public List<Pictures> Pictures { get; set; } = new();
    }
}
