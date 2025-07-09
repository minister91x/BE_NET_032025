namespace BE_032025.NetCoreWeb.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public int CategoryID { get; set; }
    }
}
