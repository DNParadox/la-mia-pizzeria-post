using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Extensions.Hosting;


namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        PizzeriaDbContext db;

        public PizzaController() : base()
        {
            // Usiamo Data quindi DB
            // Metodo mostrato da Paolo per dichiarare soltanto una volta il nostro DB anziché di volta in volta 
            db = new PizzeriaDbContext();
        }
        //Read 
        public IActionResult Index()
        {
            // Usiamo Data quindi DB . Metodo Vecchio dove bisognava dichiarare di volta in volta il db in uso
            //PizzeriaDbContext db = new PizzeriaDbContext();


            // Usiamo Model
            List<Pizza> Pizzas = db.Pizzas.ToList();


            // In return possiamo passare un singolo argomento
            return View(Pizzas);
        }

        public IActionResult Detail(int id)
        {


            Pizza Pizzas = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

            return View(Pizzas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Equivalente di CSRF di Laravel
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza Pizzas)
        {
            if (!ModelState.IsValid)
            {
                //return View(post);
                return View();
            }

            // Pusha nel db con .add
            db.Pizzas.Add(Pizzas);
            //Salva i cambiamenti effettuati
            db.SaveChanges();


            //Redirect alla Index quindi alla lista di pizze creata
            return RedirectToAction("Index");
        }
    }
}
