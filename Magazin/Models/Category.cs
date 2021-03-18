using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Img { get; set; }
        [JsonIgnore]
        public List<Produs> Produse { get; set; }
    }
}
