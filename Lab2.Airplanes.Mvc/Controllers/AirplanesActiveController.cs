using Lab2.Airplanes.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Airplanes.Mvc.Controllers
{
    public class AirplanesActiveController : Controller
    {
        private readonly AirplanesApiClient _api;

        public AirplanesActiveController(AirplanesApiClient api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _api.GetActiveAsync();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inactivate(int id)
        {
            await _api.InactivateAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
