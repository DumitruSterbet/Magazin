using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string User { get; set; } 
        public string Address { get; set; } 
        public string ContactPhone { get; set; } 
        [JsonIgnore]
        public int ProdusId { get; set; } 
        [JsonIgnore]
        public Produs Produs{ get; set; }
    }
}
