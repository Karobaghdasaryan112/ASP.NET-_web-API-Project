using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET__web_API_Project.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private OrderService _orderService;
        private ILogger<OrderController> _logger;   
        public OrderController(OrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CrateOrder(Product product, Customer customer)
        {
            try
            {
                await _orderService.CreateOrder(product, customer);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateOrderParams")]
        public async Task<IActionResult> CreateOrderParams(Customer Customer, Product[] product)
        {
            try
            {
                await _orderService.CreateOrder(Customer, product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetOrderById")]
        public async Task<Order> GetOrderById(int OrderId)
        {
            try
            {
                var Order = await _orderService.GetOrderById(OrderId);
                return Order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentException(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetOrderByCustomerName")]
        public async Task<Order> GetOrderByCustomerName(string CustomerName)
        {
            try
            {
                var Order = await _orderService.GetOrderByCustomerName(CustomerName);
                return Order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentException(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateOrderByCustomerId")]
        public async Task<IActionResult> UpdateOrderByCustomerId(Order order)
        {
            try
            {
                await _orderService.UpdateOrderByCustomerId(order);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteOrderById")]
        public async Task<IActionResult> DeleteOrderById(int OrderId)
        {
            try
            {
                await _orderService.DeleteOrderById(OrderId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
