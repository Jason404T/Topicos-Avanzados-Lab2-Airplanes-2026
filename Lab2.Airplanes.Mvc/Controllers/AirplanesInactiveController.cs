using Lab2.Airplanes.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Airplanes.Mvc.Controllers
{
    public class AirplanesInactiveController : Controller
    {
        private readonly AirplanesApiClient _api;

        public AirplanesInactiveController(AirplanesApiClient api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _api.GetInactiveAsync();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activate(int id)
        {
            await _api.ActivateAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
