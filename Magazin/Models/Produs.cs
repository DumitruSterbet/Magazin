using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin.Models
{
    public class Produs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        public string Path { get; set; }
        public int Price { get; set; }
         public bool Favourite { get; set; }
        
        public int categoryID { get; set; }
       
        public virtual Category category { get; set; }

       
    }
}


