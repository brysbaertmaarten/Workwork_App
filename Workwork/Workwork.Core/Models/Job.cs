using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workwork.Functions.Models
{
    public class Job
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("payment")]
        public string Payment { get; set; }

        [JsonProperty("postTime")]
        public DateTime PostTime { get; set; }

        [JsonProperty("isDone")]
        public bool IsDone { get; set; }

        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        [JsonProperty("contactInfoId")]
        public Guid ContactInfoId { get; set; }

        [JsonProperty("locationId")]
        public Guid LocationId { get; set; }
    }
}
