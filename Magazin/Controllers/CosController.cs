using Magazin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin.Controllers
{
    public class CosController : Controller
    {
        ShopContext db;
        static public List<Produs> produse = new List<Produs>();

        public CosController (ShopContext context)
        {
            db = context;
        }

        public IActionResult Add(int? id)
        {   if (id == null) return RedirectToAction("Index", "Visitator");
                
                Produs obj = new();
                obj = db.Produse.FirstOrDefault(u => u.Id == id);
            produse.Add(obj);

            return RedirectToAction("Index", "Visitator");
        }
        public IActionResult Show()
        {
            double media = 0;
            if (produse.Any())
            {
                media = produse.Average(u => u.Price);
            }
            ViewBag.Average = media;
            return View(produse);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Show", "Cos");
            Produs obj = new();
            obj = produse.FirstOrDefault(u => u.Id == id);
            produse.Remove(obj);
            
            return RedirectToAction("Show", "Cos");
        }
    }
}
