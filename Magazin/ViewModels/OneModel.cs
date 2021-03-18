using Magazin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin.ViewModels
{
    public class OneModel
    {
        public Produs produs { get; set; }
        public Category category { get; set; }
        public Order order { get; set; }
        public Admin admin { get; set; }


    }
}
