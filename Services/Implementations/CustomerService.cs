using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Repositories.implementations;
using ASP.NET__web_API_Project.Services.Interfaces;
using ASP.NET_web_API_Project.Data;

namespace ASP.NET__web_API_Project.Services.Implementations
{
    public class CustomerService : ICustomerService
    {

        private CustomerRepository _customerRepository { get; set; }
        public CustomerService(CustomerRepository customerRepository)
        {

            _customerRepository = customerRepository;
        }

        public async Task CreateCustomer(Customer customer)
        {
            await _customerRepository.CreateCustomer(customer);
        }

        public async Task CreateCustomer(string Name, string Email)
        {
            await _customerRepository.CreateCustomer(Name, Email);
        }

        public async Task<Customer> GetCustomerById(int ProductId)
        {
            return await _customerRepository.GetCustomerById(ProductId);
        }

        public async Task<Customer> GetCustomerByName(string ProductName)
        {
            return await _customerRepository.GetCustomerByName(ProductName);
        }

        public async Task UpdateCustomerById(Customer customer)
        {
            await _customerRepository.UpdateCustomerById(customer);
        }

        public async Task DeleteCustomerByName(string CustomerName)
        {
            await _customerRepository.DeleteCustomerByName(CustomerName);
        }

        public async Task DeleteCustomerByID(int CustomerId)
        {
            await _customerRepository.DeleteCustomerByID(CustomerId);
        }
    }
}
