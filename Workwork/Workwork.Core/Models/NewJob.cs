using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workwork.Functions.Models
{
    public class NewJob
    {
        public Job Job { get; set; }
        public Location Location { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
