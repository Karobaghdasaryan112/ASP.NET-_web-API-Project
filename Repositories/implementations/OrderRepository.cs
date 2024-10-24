using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Repositories.Interfaces;
using ASP.NET_web_API_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET__web_API_Project.Repositories.implementations
{
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext _context { get; set; }
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(Product product, Customer customer)
        {
            Order order = new Order()
            {
                CustomerId = customer.CustomerId,
                OrderDate = DateTime.Now,
            };
            Order FindOrder = await _context.Orders.FirstOrDefaultAsync(order => order.CustomerId == customer.CustomerId);
            if (FindOrder == null)
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException(nameof(FindOrder));
        }

        public async Task CreateOrder(Customer customer, params Product[] Product)
        {
            List<Product> products = Product.ToList();
            Order order = new Order()
            {
                CustomerId = customer.CustomerId,
                OrderDate = DateTime.Now,
            };
            Order FindOrder = await _context.Orders.FirstOrDefaultAsync(order => order.CustomerId == customer.CustomerId);
            if (FindOrder == null)
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException();
        }

        public async Task<Order> GetOrderById(int OrderId)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(order => order.OrderId == OrderId);
            if (order != null)
                return order;
            throw new ArgumentNullException();
        }

        public async Task<Order> GetOrderByCustomerName(string CustomerName)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(Customer => Customer.Name == CustomerName);
            Order order1 = await _context.Orders.FirstOrDefaultAsync(order => order.CustomerId == customer.CustomerId);
            if (order1 != null)
                return order1;
            throw new ArgumentNullException();
        }

        public async Task UpdateOrderByCustomerId(Order order)
        {
            Order FindOrder = await _context.Orders.FirstOrDefaultAsync(order => order.CustomerId == order.CustomerId);
            if (FindOrder != null)
            {
                FindOrder.OrderDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException();
        }

        public async Task DeleteOrderById(int OrderId)
        {
            Order FindOrder = await _context.Orders.FirstOrDefaultAsync(order => order.OrderId == OrderId);
            if (FindOrder != null)
            {
                _context.Orders.Remove(FindOrder);
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException();
        }
    }
}
