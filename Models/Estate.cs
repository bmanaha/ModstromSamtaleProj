using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2samtopg.Models
{
    public class Estate
    {
        public int Id { get; set; }
        public int Owner_id { get; set; }

        [ScaffoldColumn(true)]
        [StringLength(200, ErrorMessage = "Streetname cannot exceed 200 characters. ")]
        public string Streetname { get; set; }

        public string Housenumber { get; set; } //husnr

        public int Zipcode { get; set; } //postnr

    }
}
