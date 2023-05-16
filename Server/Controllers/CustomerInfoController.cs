using Assignment2.Server.Data;
using Assignment2.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {

        [HttpGet("/ListCustomers")]
        public IActionResult Get(string id)
        {
            var options = new DbContextOptionsBuilder<MyDBContext>().UseSqlServer("Data Source=MAS-Desktop;Initial Catalog=CustomerInfo;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;").Options;
            var DB = new MyDBContext(options);
            var customer = DB.CustomerInfo.ToList();
            return Ok(customer);
        }

        [HttpPut("/Save/{id}/{name}/{phone}/{address}")]
        public IActionResult Put(string id, string name, string phone, string address)
        {
            var options = new DbContextOptionsBuilder<MyDBContext>().UseSqlServer("Data Source=MAS-Desktop;Initial Catalog=CustomerInfo;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;").Options;
            var DB = new MyDBContext(options);
            var new_customer = new CustomerInfo
            {
                CustomerId = id,
                CustomerName = name,
                CustomerPhoneNo = phone,
                CustomerAddress = address
            };
            DB.CustomerInfo.Add(new_customer);
            DB.SaveChanges();
            return Ok(new_customer);
        }

    }
}
