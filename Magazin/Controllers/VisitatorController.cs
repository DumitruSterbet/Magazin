using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Magazin.Models;
using Magazin.ViewModels;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using System;
using Serilog;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Magazin.Security;

namespace Magazin.Controllers
{
    public class VisitatorController :Controller
    {
        ShopContext db;
        private readonly Microsoft.Extensions.Logging.ILogger logger;
        public NotNull notNull = new NotNull();

        public VisitatorController(ShopContext context,ILogger<VisitatorController> _logger)
        {
            db = context;
            logger = _logger;
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Visitator");
        }
        public IActionResult Index() // Pagina cu toate produsele
        {
            logger.LogInformation("Metoda index a fost accesata");
                     return View(); 
           
        }
         public IActionResult Favourite() // Pagina cu produsele favorite
        {
            ViewModel obj = new ViewModel();
            OneModel A = new OneModel();
            List<Produs> ListA = new List<Produs>();
            obj.viewProdus = db.Produse.ToList();
            for (int i = 0; i < obj.viewProdus.Count(); i++)
            {
                if (obj.viewProdus[i].Favourite == true)
                {
                    A.produs = obj.viewProdus[i];
                    ListA.Add(A.produs);
                }
            }
            logger.LogInformation("Metoda Favourite() a fost accesata");
            return View(ListA);
        }
      


        public IActionResult Categorii(int id)// functia pentru sortare dupa categorii
        {
            ViewModel obj = new ViewModel();
            OneModel A = new OneModel();
            List<Produs> ListA = new List<Produs>();
            obj.viewProdus = db.Produse.ToList();
            for (int i = 0; i < obj.viewProdus.Count(); i++)
            { 
                if (obj.viewProdus[i].categoryID == id)
                {
                    A.produs = obj.viewProdus[i];
                    ListA.Add(A.produs);
                }
            }
            logger.LogInformation("Metoda Categorii() a fost accesata");
            return View(ListA);
        }
        public IActionResult workEmail()
        {
            return View();
        }
        public IActionResult Details(int id)// Detaliile la un anumit produs
        {
            ViewModel obj = new ViewModel();
            obj.viewProdus = db.Produse.ToList();

            Produs v = new Produs();
            v = obj.viewProdus.FirstOrDefault(x => x.Id == id);
            logger.LogInformation($"Metoda Details() a fost accesata cu id = {id}");
            return View(v);
        }
       
        // Citirea paginii admin mode
        [HttpGet]
        
        public IActionResult Loghin()
        {
            ViewModel obj = new ViewModel();
            obj.viewAdmin = db.Admins.ToList();
            logger.LogInformation("Incercare de a se loga ca admin");
            return View(obj.viewAdmin[0]);
        }


        // Metoda de intrare in admin Mode
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Loghin(Admin ad)
        {
            
            if (ModelState.IsValid)
            {
                Admin user = await db.Admins.FirstOrDefaultAsync(u => u.login == ad.login && u.password == ad.password);
                if (user != null)
                {
                    await Authenticate(ad.login);

                    return RedirectToAction("Meniu_manager", "Administrator");
                }
               
            }
            ErrorLoghin(ad);
            
            return View();

        }
        //Erori la logare
        public void ErrorLoghin(Admin ad)
        {
            NotNull notNull = new NotNull();
            int k = notNull.securitLoghin(ad);
            if (k == 1)
            {
                ViewBag.Err1 = notNull.errorMessage;
            }
            if (k == 2)
            {
                ViewBag.Err2 = notNull.errorMessage;
            }

            if (k == 3)
            {
                ViewBag.Err1 = notNull.errorMessage;
                ViewBag.Err2 = notNull.errorMessage;
            }
            if (k == 0)
            {
                ViewBag.Err = "Asa utilizator nu exista";
            }
        }
        // Meniiu  categorii
        [HttpGet]
        public IActionResult Meniu_Categorii()
        {
            ViewModel obj = new ViewModel();
            obj.viewProdus = db.Produse.ToList();
            obj.viewCategory = db.Categories.ToList();
            logger.LogInformation("Metoda Meniu_Categorii() a fost accesata");
            return View(obj);
        }

        // Metoda de inscriere a facturii in BD
       
    }
}
