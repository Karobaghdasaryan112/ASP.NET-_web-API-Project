using ASP.NET__web_API_Project.Models;

namespace ASP.NET__web_API_Project.Services.Interfaces
{
    public interface IOrderService
    {
        //C.R.U.D
        //Creat
        Task CreateOrder(Product product, Customer customer);
        Task CreateOrder(Customer customer, params Product[] Product);

        //Read
        Task<Order> GetOrderById(int OrderId);
        Task<Order> GetOrderByCustomerName(string CustomerName);

        //Update
        Task UpdateOrderByCustomerId(Order order);

        //Delete
        Task DeleteOrderById(int OrderId);
    }
}
