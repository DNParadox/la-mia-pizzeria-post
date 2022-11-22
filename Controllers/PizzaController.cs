using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Extensions.Hosting;


namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            // Usiamo Data quindi DB
            PizzeriaDbContext db = new PizzeriaDbContext();


            // Usiamo Model
            List<Pizza> Pizzas = db.Pizzas.ToList();


            // In return possiamo passare un singolo argomento
            return View(Pizzas);
        }

        public IActionResult Detail(int id)
        {

            PizzeriaDbContext db = new PizzeriaDbContext();

            Pizza Pizzas = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

            return View(Pizzas);
        }
    }
}
