using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2samtopg.Models
{
    public class Addresse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("darstatus")]
        public int DarStatus { get; set; }

        [JsonProperty("vejkode")]
        public string VejKode { get; set; }

        [JsonProperty("vejnavn")]
        public string VejNavn { get; set; }

        [JsonProperty("adresseringsvejnavn")]
        public string AdresseringsVejNavn { get; set; }

        [JsonProperty("husnr")]
        public string Husnr { get; set; }

        [JsonProperty("etage")]
        public string Etage { get; set; }

        [JsonProperty("dør")]
        public string Dør { get; set; }

        [JsonProperty("supplerendebynavn")]
        public string SupplerendeByNavn { get; set; }
        [JsonProperty("postnr")]
        public string Postnr { get; set; }
        [JsonProperty("postnrnavn")]
        public string PostnrNavn { get; set; }

        [JsonProperty("stormodtagerpostnr")]
        public string StormodtagerPostnr { get; set; }

        [JsonProperty("stormodtagerpostnrnavn")]
        public string StormodtagerPostnrNavn { get; set; }

        [JsonProperty("kommunekode")]
        public string KommuneKode { get; set; }

        [JsonProperty("adgangsadresseid")]
        public Guid AdgangsAdresseId { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("betegnelse")]
        public string Betegnelse { get; set; }
    }
}
