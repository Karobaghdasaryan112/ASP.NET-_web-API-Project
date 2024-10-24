using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Repositories.implementations;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET__web_API_Project.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ILogger<CustomerController> _logger { get; set; }
        private CustomerRepository _customerRepository;
        public CustomerController(ILogger<CustomerController> logger, CustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            try
            {
                await _customerRepository.CreateCustomer(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateCustomerNameEmail")]
        public async Task<IActionResult> CreateCustomerNameEmail(string name, string Email)
        {
            try
            {
                await _customerRepository.CreateCustomer(name, Email);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<Customer> GetCustomerById(int customer)
        {
            try
            {
                var Customer = await _customerRepository.GetCustomerById(customer);
                return Customer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentNullException(nameof(customer), ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCustomerByName")]
        public async Task<Customer> GetCustomerByName(string customer)
        {
            try
            {
                var Customer = await _customerRepository.GetCustomerByName(customer);
                return Customer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentNullException($"Customer name: {customer}");
            }
        }
        [HttpPut]
        [Route("UpdateCustomerById")]
        public async Task<IActionResult> UpdateCustomerById(Customer customer)
        {
            try
            {
                await _customerRepository.UpdateCustomerById(customer);
                return Ok();
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("DeleteCustomerByName")]
        public async Task<IActionResult> DeleteCustomerByName(string CustomerName)
        {
            try
            {
                await _customerRepository.DeleteCustomerByName(CustomerName);
                return Ok();
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteCustomerByID")]
        public async Task<IActionResult> DeleteCustomerByID(int CustomerID)
        {
            try
            {
                await _customerRepository.DeleteCustomerByID(CustomerID);
                return Ok();
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
