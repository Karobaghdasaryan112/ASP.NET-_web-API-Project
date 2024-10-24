using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASP.NET__web_API_Project.Models
{
    public class Product
    {
        [JsonIgnore]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}