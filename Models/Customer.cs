using System.Text.Json.Serialization;

namespace ASP.NET__web_API_Project.Models
{
    public class Customer
    {

        public int CustomerId { get; set; }          
        public string Name { get; set; }   
        public string Email { get; set; }     
        public string Address { get; set; }   

    }
}
