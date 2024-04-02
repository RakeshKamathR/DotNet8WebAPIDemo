namespace DotNet8WebAPIDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public string tags { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
    }
}
