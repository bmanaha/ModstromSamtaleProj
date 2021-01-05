using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2samtopg.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [ScaffoldColumn(true)]
        [StringLength(200, ErrorMessage = "Property cannot exceed 200 characters. ")]
        public string Firstname { get; set; }

        [ScaffoldColumn(true)]
        [StringLength(200, ErrorMessage = "Property cannot exceed 200 characters. ")]
        public string Lastname { get; set; }
    }
}
