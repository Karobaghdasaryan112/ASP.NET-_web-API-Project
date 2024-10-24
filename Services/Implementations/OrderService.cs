using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Repositories.implementations;
using ASP.NET__web_API_Project.Services.Interfaces;
using ASP.NET_web_API_Project.Data;

namespace ASP.NET__web_API_Project.Services.Implementations
{
    public class OrderService : IOrderService
    {

        private OrderRepository _orderRepository { get; set; }
        public OrderService(OrderRepository orderRepository)
        {

            _orderRepository = orderRepository;
        }

        public async Task CreateOrder(Product product, Customer customer)
        {
            await _orderRepository.CreateOrder(product, customer);
        }

        public async Task CreateOrder(Customer customer, params Product[] Product)
        {
            await _orderRepository.CreateOrder(customer,Product);
        }

        public async Task<Order> GetOrderById(int OrderId)
        {
            return await _orderRepository.GetOrderById(OrderId);
        }

        public async Task<Order> GetOrderByCustomerName(string CustomerName)
        {
            return await _orderRepository.GetOrderByCustomerName(CustomerName);
        }

        public async Task UpdateOrderByCustomerId(Order order)
        {
            await _orderRepository.UpdateOrderByCustomerId(order);
        }

        public async Task DeleteOrderById(int OrderId)
        {
            await _orderRepository.DeleteOrderById(OrderId);    
        }
    }
}
