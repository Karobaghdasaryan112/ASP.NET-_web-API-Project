using ASP.NET__web_API_Project.Models;

namespace ASP.NET__web_API_Project.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        //C.R.U.D
        //Creat
        Task CreateCustomer(Customer customer);
        Task CreateCustomer(string Name,string Email);

        //Read
        Task<Customer> GetCustomerById(int ProductId);
        Task<Customer> GetCustomerByName(string ProductName);

        //Update    
        Task UpdateCustomerById(Customer customer);
        //Delete
        Task DeleteCustomerByName(string CustomerName);
        Task DeleteCustomerByID(int CustomerId);
    }
}
