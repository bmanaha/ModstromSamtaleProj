using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using _2samtopg.Models;

namespace _2samtopg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var rng = new Random();
            return Enumerable.Range(2, 5).Select(index => new Customer
            {
                Id = rng.Next(1, 200),
                Firstname = "1",
                Lastname = "2"
            })
            .ToArray();
        }

        [HttpGet("pluckaddr")]
        public string pluck()
        {
            //EndPoint.uri.ToString();
            return "";
        }
}
}
