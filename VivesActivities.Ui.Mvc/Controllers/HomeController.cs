using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VivesActivities.Services;
using VivesActivities.Ui.Mvc.Models;

namespace VivesActivities.Ui.Mvc.Controllers
{
    public class HomeController(VivesActivityService activityService) : Controller
    {
        public IActionResult Index()
        {
            var activities = activityService.Find();
            return View(activities);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}