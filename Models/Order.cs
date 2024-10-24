using System.Text.Json.Serialization;

namespace ASP.NET__web_API_Project.Models
{
    public class Order
    {
        [JsonIgnore]
        public int OrderId { get; set; }           
        public DateTime OrderDate { get; set; } 
        public int CustomerId { get; set; }  
    }
}
