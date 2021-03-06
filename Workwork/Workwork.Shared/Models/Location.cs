﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workwork.Functions.Models
{
    public class Location
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        public override string ToString()
        {
            return Street.Replace(" ", string.Empty) + " " + Number.Replace(" ", string.Empty) + ", " + City.Replace(" ", string.Empty) + " " + Country.Replace(" ", string.Empty);
        }
    }
}
