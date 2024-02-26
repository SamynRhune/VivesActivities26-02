using Microsoft.AspNetCore.Mvc;
using VivesActivities.Model;
using VivesActivities.Services;

namespace VivesActivities.Ui.Mvc.Controllers
{
    public class LocationsController(LocationService locationService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var locations = locationService.Find();
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Location location)
        {
            if (!ModelState.IsValid)
            {
                return View(location);
            }

            locationService.Create(location);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var location = locationService.Get(id);

            if (location is null)
            {
                return RedirectToAction("Index");
            }

            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Location location)
        {
            if (!ModelState.IsValid)
            {
                return View(location);
            }

            locationService.Update(id, location);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var location = locationService.Get(id);

            if (location is null)
            {
                return RedirectToAction("Index");
            }

            return View(location);
        }

        [HttpPost("[controller]/delete/{id:int?}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            locationService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
