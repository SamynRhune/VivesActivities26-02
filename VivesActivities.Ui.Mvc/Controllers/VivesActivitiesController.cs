using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VivesActivities.Model;
using VivesActivities.Services;

namespace VivesActivities.Ui.Mvc.Controllers
{
    [Authorize]
    public class VivesActivitiesController(
        VivesActivityService activityService,
        LocationService locationService) : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var activities = activityService.Find();
            return View(activities);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return VivesActivityView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VivesActivity activity)
        {
            if (!ModelState.IsValid)
            {
                return VivesActivityView(activity);
            }

            activityService.Create(activity);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var activity = activityService.Get(id);

            if (activity is null)
            {
                return RedirectToAction("Index");
            }

            return VivesActivityView(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VivesActivity activity)
        {
            if (!ModelState.IsValid)
            {
                return VivesActivityView(activity);
            }

            activityService.Update(id, activity);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var activity = activityService.Get(id);

            if (activity is null)
            {
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        [HttpPost("[controller]/delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            activityService.Delete(id);

            return RedirectToAction("Index");
        }
        
        private IActionResult VivesActivityView(VivesActivity? activity = null, [CallerMemberName] string? viewName = null)
        {
            var locations = locationService.Find();
            ViewBag.Locations = locations;

            if (activity is null)
            {
                return View(viewName);
            }

            return View(viewName, activity);
        }
    }
}
