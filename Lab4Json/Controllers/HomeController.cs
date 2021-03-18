using Lab4Json.Models;
using Lab4Json.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Json.Controllers
{
    public class HomeController : Controller
    {
        FacultateContext db;

        public HomeController(FacultateContext _db)
        {
            db = _db;
            
        }

        public IActionResult Index()
        {
          
            return View();
        }
        
        [HttpGet]
        public IActionResult Show(int id)
        {
          
            return View(id);
        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public JsonResult AjaxMethod([FromBody] string name)
        {
            PersonModel person = new PersonModel
            {
                Name = name
               
            };
            return Json(person);
        }



    }
}
