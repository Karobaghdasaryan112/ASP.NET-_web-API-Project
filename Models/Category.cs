using System.Text.Json.Serialization;

namespace ASP.NET__web_API_Project.Models
{
    public class Category
    {
        [JsonIgnore]
        public int CategoryId { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; } 
    }
}
