using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using _2samtopg.Models;

namespace _2samtopg.DB
{
    public class LiteDBHelper
    {
        const string DBpath = @"C:\TempDeleteMe\TEST.db"; // make sure c:\TempDeleteMe folder exists
        public List<Customer> GetAllCustomers()
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(DBpath))
            {
                // Get a collection (or create, if doesn't exist)
                return db.GetCollection<Customer>("customers").FindAll().ToList();
            }
        }

        public Customer GetCustomerById(int _id)
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(DBpath))
            {
                // Get a collection (or create, if doesn't exist)
                return db.GetCollection<Customer>("customers").FindById(_id);
            }
        }

        public Customer InsertCustomer(string _fname, string _lname)
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(DBpath))
            {
                
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Customer>("customers");
                var _customer = new Customer { Firstname = _fname, Lastname = _lname };

                col.Insert(_customer);
                return _customer;
            }
        }

        public List<Estate> GetAllEstates()
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(DBpath))
            {
                // Get a collection (or create, if doesn't exist)
                return db.GetCollection<Estate>("estates").FindAll().ToList();
            }
        }

        public Estate GetEstateById(int _id)
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(DBpath))
            {
                // Get a collection (or create, if doesn't exist)
                return db.GetCollection<Estate>("estates").FindById(_id);
            }
        }

        public List<Estate> GetAllEstateByAddresses(string _streetname, string _housenumber,int _zipcode)
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(DBpath))
            {
                // Get a collection (or create, if doesn't exist)
                return db.GetCollection<Estate>("estates").FindAll()
                       .Where(e =>
                       e.Streetname.Equals(_streetname) &&
                       e.Housenumber.Equals(_housenumber) &&
                       e.Zipcode.Equals(_zipcode)
                       ).ToList();
            }
        }

        public List<Estate> GetAllEstateByOwnerId(int _owner_id)
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(DBpath))
            {
                // Get a collection (or create, if doesn't exist)
                return db.GetCollection<Estate>("estates")
                    .FindAll()
                    .Where(e =>
                        e.Owner_id.Equals(_owner_id)
                    ).ToList();
            }
        }

        public void InsertEstate(Estate _estate)
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(DBpath))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Estate>("estates");
                col.Insert(_estate);
            }
        }



    }
}
