using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin.Models
{
    public class OrderProdus
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProdusId { get; set; }
        public Produs Produs { get; set; }
    }
}
