using Microsoft.AspNetCore.Mvc;
using CustomerService;
using System.Linq;

namespace CustomerService.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private static List<Customer> _customers = new List<Customer>() {
     new Customer() {
         Id = 1,
         Name = "International Bicycles A/S",
         Address1 = "Nydamsvej 8",
         Address2 = null,
         PostalCode = 8362,
         City = "H�rning",
         TaxNumber = "DK-75627732",
         ContactName = "Dennis Jørgensen"
     }
 };

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{customerId}",Name="GetCustomerById")]
    public Customer Get(int customerId)
    {
        return _customers.Where(c => c.Id == customerId).First();
    }
}