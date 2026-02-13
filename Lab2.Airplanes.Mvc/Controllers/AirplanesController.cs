using Lab2.Airplanes.Mvc.Models;
using Lab2.Airplanes.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Airplanes.Mvc.Controllers
{
    public class AirplanesController : Controller
    {
        private readonly AirplanesApiClient _api;

        public AirplanesController(AirplanesApiClient api)
        {
            _api = api;
        }

        // GET: /Airplanes
        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAllAsync();
            return View(list);
        }

        // GET: /Airplanes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _api.GetByIdAsync(id);
            if (item is null) return NotFound();
            return View(item);
        }

        // GET: /Airplanes/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new AirplaneViewModel { Status = 1 });
        }

        // POST: /Airplanes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AirplaneViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var ok = await _api.CreateAsync(vm);
            if (!ok)
            {
                ModelState.AddModelError("", "Could not create airplane.");
                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Airplanes/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _api.GetByIdAsync(id);
            if (item is null) return NotFound();
            return View(item);
        }

        // POST: /Airplanes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AirplaneViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var ok = await _api.UpdateAsync(vm);
            if (!ok)
            {
                ModelState.AddModelError("", "Could not update airplane.");
                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
