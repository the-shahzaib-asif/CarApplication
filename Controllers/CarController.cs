using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CarController : Controller
    {

        private static List<Car> availableCars = new List<Car>
        {
            new Car { Id = 1, Name = "Alto", PricePerDay = 3000 },
            new Car { Id = 2, Name = "Corolla", PricePerDay = 6000 },
            new Car { Id = 3, Name = "Civic", PricePerDay = 8000 }

        };

        private static List<Car> bookedCar = new List<Car>
        {

        };
        public IActionResult Index()
        {
            return View(availableCars);
        }

        public IActionResult Booked()
        {
            return View(bookedCar);
        }

        public RedirectToActionResult Book(int id)
        {
            //firstDefualt use to return the first match
            Car selectedCar = availableCars.FirstOrDefault(c => c.Id == id);


            if (selectedCar != null)
            {
                availableCars.Remove(selectedCar);
                bookedCar.Add(selectedCar);


                return RedirectToAction("Booked");
            }


            return RedirectToAction("Index");
        }

    }
}
