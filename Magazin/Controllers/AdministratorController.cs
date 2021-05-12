using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Magazin.Models;
using Magazin.ViewModels;
using Magazin;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Magazin.JoinsModels;

namespace Magazin.Controllers
{
    public class AdministratorController : Controller
    {
        ShopContext db;
        IWebHostEnvironment appEnvironment;
        private readonly Microsoft.Extensions.Logging.ILogger logger;
        public AdministratorController(ShopContext context, ILogger<VisitatorController> _logger, IWebHostEnvironment _appEnvironment)
        {
            logger = _logger;
            db = context;
            appEnvironment = _appEnvironment;

        }
       
        // Produsele pentru manager
        [HttpGet]
        [Authorize]
        public IActionResult Meniu_manager()
        {
            ViewModel obj = new ViewModel();
            obj.viewProdus = db.Produse.ToList();
            logger.LogInformation("Pagina principala Admin a fost accesata");
            return View(obj);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return Content(User.Identity.Name);
        }
        [HttpPost]// Adaugarea Produs in BD
        public async Task<IActionResult> Add(IFormFile uploadedFile,Produs produs)
        {
            if (uploadedFile != null)
            {
               
                string path = "/img/Produse/" + uploadedFile.FileName;
               
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                string way = "/img/Produse/";
                Produs file = new Produs { Img = uploadedFile.FileName, Path = way };
                Produs obj = new Produs
                {
                    Name = produs.Name,
                    Company = produs.Company,
                    Desc = produs.Desc,
                    Img = file.Img,
                    Path = file.Path,
                    Price = produs.Price,
                    Favourite = produs.Favourite,
                    categoryID = produs.categoryID,
                    category = produs.category

                };
                db.Produse.Add(obj);
                db.SaveChanges();
            }

            logger.LogInformation("Admin a adaugat un nou produs");
            return RedirectToAction("Meniu_manager");
        }
      
        [HttpGet]
        public IActionResult Logs()
        {

            ViewModel obj = new ViewModel();
            obj.viewLog = db.Logs.ToList();
            return View(obj.viewLog);
        }
        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path =  fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }


        [HttpGet]
        public IActionResult Show(int id)
        {
            ViewModel obj = new ViewModel();
            obj.viewProdus = db.Produse.ToList();
            Produs v = new Produs();
            v = obj.viewProdus.FirstOrDefault( x => x.Id == id);
            logger.LogInformation($"Admin acceseaza desfasurat produsul cu id {id}");
            return View(v);
        }
        public IActionResult Orders()
        {

            logger.LogInformation($"Admin incearca sa vada orderele");

            List<FullOrder> obj = new List<FullOrder>();
            obj = join();


            return View(obj);
        }
        [HttpGet]
        public IActionResult Change(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            logger.LogInformation($"Admin incearca sa modifice produsul cu id: {id}");
            ViewBag.ProdusId = id;
            Produs obj = new Produs();
            obj = db.Produse.FirstOrDefault(u => u.Id == id);
           

            return View(obj);
        }
       

        [HttpPost]// Modificarea produs
        public async Task<IActionResult> Change(IFormFile uploadedFile, Produs produs,int id)
        {
            if (uploadedFile != null)
            {

                string path = "/img/Produse/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                string way = "/img/Produse/";
                
                Produs obj = new Produs
                { Id = id,
                    Name = produs.Name,
                    Company = produs.Company,
                    Desc = produs.Desc,
                    Img = uploadedFile.FileName,
                    Path = way,
                    Price = produs.Price,
                    Favourite = produs.Favourite,
                    categoryID = produs.categoryID,
                    category = produs.category

                };
                Produs ob2 = db.Produse.Where(s => s.Id == produs.Id).FirstOrDefault();
                db.Produse.Remove(ob2);
                db.Produse.Add(obj);
               
                
                db.SaveChanges();
            }

            logger.LogInformation($"Admin a modificat produsul cu id {{id}}");
            return RedirectToAction("Meniu_manager");
        }
        [HttpGet]
        public IActionResult Add()
        {
            logger.LogInformation("Admin incearca sa adauge produs");
            return View();
        }

       

        // Stergerea produsului
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewModel obj = new ViewModel();
            obj.viewProdus = db.Produse.ToList();
            Produs A = new Produs();
            A = obj.viewProdus.FirstOrDefault(x => x.Id == id);
            db.Produse.Remove(A);
           
            db.SaveChanges();
            logger.LogInformation($"Admin a sters produs cu Id {id}");
            return RedirectToAction("Meniu_manager");
        }

        public List<FullOrder> join()
        {
          

            IEnumerable<OrderWithProdName> first = new List<OrderWithProdName>();
            first = db.OrdersProdus.Join(db.Produse,
                u => u.ProdusId,
                p => p.Id,
                (u, p) => new OrderWithProdName
                { Id = u.Id, OrderId = u.OrderId, Order = u.Order, Produs = p.Name }

                );
            List<FullOrder>last =new List<FullOrder>();
            last = first.Join(db.Orders,
                p => p.OrderId,
                u => u.OrderId,
                (p, u) => new FullOrder
                {Id=p.Id,
                Produs=p.Produs,
                Order=u.User

                }
                ).ToList(); 




            return last;
      
        }


       
    }
}