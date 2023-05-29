using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class HanzController : Controller
    {
        public IActionResult Index()
        {
            DogViewModel doggo = new DogViewModel()
            {
                Name = "Sif",
                Age = 1
            };
            return View(doggo);
        }
        public IActionResult Work()
        {
            //return View();
            return Ok("Hanz Work");
        }

    }
}
