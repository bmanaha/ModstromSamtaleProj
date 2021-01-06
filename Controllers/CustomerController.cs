using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using _2samtopg.Models;
using _2samtopg.DB;

namespace _2samtopg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private LiteDBHelper _ldb;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
            _ldb = new LiteDBHelper();
        }

        //[HttpGet("test/insert")]
        //public Customer TestInsert()
        //{
        //    var _customer = _ldb.InsertCustomer("1", "2");
        //    return _customer;
        //}

        //[HttpGet("test/getcustomers")]
        //public List<Customer> TestGetCustomers()
        //{
        //    var _customer = _ldb.GetAllCustomers();
        //    return _customer;
        //}



        [HttpGet("pluckaddr")]
        public string pluck()
        {
            //EndPoint.uri.ToString();
            return "";
        }
}
}
