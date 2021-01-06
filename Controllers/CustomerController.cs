using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using _2samtopg.Models;
using _2samtopg.Endpoint;
using _2samtopg.DB;
using System.Text.Json;
using Newtonsoft.Json;

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

        [HttpGet("test/get")]
        public List<Customer> TestGetCustomers()
        {
            var _customers = _ldb.GetAllCustomers();
            return _customers;
        }

        [HttpGet("test/getestate")]
        public List<Estate> TestGetEstate()
        {
            var _estates = _ldb.GetAllEstates();
            return _estates;
        }

        [HttpGet("pluckaddr")]
        public string Pluck()
        {
            WebRequest request = WebRequest.Create(Endpoint.EndPoint.uri); // url moved to different file, in order to keep it off git

            request.Credentials = CredentialCache.DefaultCredentials; // If required by the server, set the credentials.

            WebResponse response = request.GetResponse();

            string responseFromServer = "";
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();

                Console.WriteLine(responseFromServer);
            }
            // Close the response.
            response.Close();

            List<Addresse> addresses = JsonConvert.DeserializeObject<List<Addresse>>(responseFromServer);

            //Pluk en adresse ud der ligger i 3500 Værløse (sorterings rækkefølge underordnet hvis flere)
            var TheAddress = addresses?.FirstOrDefault<Addresse>(addr => addr.Postnr.Equals("3500")) ?? null;
            if (TheAddress != null)
            {
                Console.WriteLine($"Plucked following address {TheAddress}");

                /*
                Lav et opslag på lokaldatabase ”TEST”
                Indsæt data i Estate 
                */
                var customer = _ldb.InsertCustomer("Jens", "Hansen"); //

                var _insertTheAddressInEstate = new Estate
                {
                    Housenumber = TheAddress.Husnr,
                    Streetname = TheAddress.VejNavn,
                    Zipcode = Convert.ToInt32(TheAddress.Postnr)
                    //,Owner_id = customer.Id
                };

                _ldb.InsertEstate(_insertTheAddressInEstate);

                /*
                og find den første ejendom i Estate tabel hvor der matches på den adresse der er plukket ud i pkt. 2 mht. nedenstående
                vejnavn = Streetname
                husnr = Housenumber
                postnr = Zipcode
                */

                var MatchingEstates = _ldb.GetAllEstateByAddresses(_insertTheAddressInEstate.Streetname, _insertTheAddressInEstate.Housenumber, _insertTheAddressInEstate.Zipcode);

                /*  
                    Hvis ingen fundet, returner ”Not found” til konsol app
                    Hvis fundet, Find den kunde (Customer tabel) der står angivet som ejer via owner_id reference
                    Skriv firstname og lastname ud i konsol app
                */

                if (MatchingEstates == null || MatchingEstates.Count < 1)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    // not sure where names come from
                    //var _ownerOfMatchingEstate = _ldb.GetCustomerById(MatchingEstates.FirstOrDefault().Owner_id);
                    //Console.WriteLine(_ownerOfMatchingEstate.Firstname, _ownerOfMatchingEstate.Lastname);
                }
            }

            return responseFromServer;
}


}
}
