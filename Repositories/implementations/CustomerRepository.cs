using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Repositories.Interfaces;
using ASP.NET_web_API_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET__web_API_Project.Repositories.implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDbContext _context { get; set; }
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCustomer(Customer customer)
        {
            Customer customer1 = await _context.Customers.FirstOrDefaultAsync(Customer =>  Customer.Email == customer.Email);
            if(customer1 == null)
                await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCustomer(string Name,string Email)
        {
            Customer customer = new Customer()
            {
                Email = Email,
                Name = Name,

            };
            Customer customer1 = await _context.Customers.FindAsync(customer);
            if (customer1 == null)
                await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerById(int CustomerId)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == CustomerId); 
            if(customer == null )
                throw new ArgumentNullException(nameof(customer));
                return customer;
        }

        public async Task<Customer> GetCustomerByName(string CustomerName)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Name == CustomerName);
            if (customer != null)
                return customer;
            throw new ArgumentNullException(nameof(CustomerName));
        }


        public async Task UpdateCustomerById(Customer customer)
        {
            Customer customer1 = await _context.Customers.FirstOrDefaultAsync(Customer => Customer.Email == customer.Email);
            if(customer1 != null)
            {
                customer1.Address = customer.Address;
                customer1.Email = customer.Email;
                customer1.Name = customer.Name;
            }
            throw new ArgumentNullException();
        }

        public async Task DeleteCustomerByName(string CustomerName)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(Customer => Customer.Name == CustomerName);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException();
        }

        public async Task DeleteCustomerByID(int CustomerId)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(Customer => Customer.CustomerId == CustomerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException();
        }
    }
}
