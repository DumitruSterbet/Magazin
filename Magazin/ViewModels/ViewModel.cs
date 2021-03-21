using Magazin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin.ViewModels
{
    public class ViewModel
    {
        public List<Produs> viewProdus { get; set; }
        public List<Category> viewCategory { get; set; }
         public List<Admin> viewAdmin { get; set; }
        public List<Order> viewOrder { get; set; }
        public List<Log> viewLog { get; set; }
        public List<OrderProdus> viewOrderProdus { get; set; }
      
    }
}
