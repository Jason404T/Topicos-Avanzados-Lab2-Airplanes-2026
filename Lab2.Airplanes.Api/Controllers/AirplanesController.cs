using Lab2.Airplanes.Api.Application.DTOs;
using Lab2.Airplanes.Api.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Airplanes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirplanesController : ControllerBase
    {
        private readonly AirplaneService _service;

        public AirplanesController(AirplaneService service)
        {
            _service = service;
        }

        // GET: api/airplanes
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/airplanes/active
        [HttpGet("active")]
        public IActionResult GetActive()
        {
            return Ok(_service.GetActive());
        }

        // GET: api/airplanes/inactive
        [HttpGet("inactive")]
        public IActionResult GetInactive()
        {
            return Ok(_service.GetInactive());
        }

        // GET: api/airplanes/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _service.GetById(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        // POST: api/airplanes
        [HttpPost]
        public IActionResult Create([FromBody] AirplaneCreateDto dto)
        {
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/airplanes/5
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] AirplaneUpdateDto dto)
        {
            var ok = _service.Update(id, dto);
            if (!ok) return NotFound();
            return NoContent();
        }

        // PATCH: api/airplanes/5/inactivate
        [HttpPatch("{id:int}/inactivate")]
        public IActionResult Inactivate(int id)
        {
            var ok = _service.Inactivate(id);
            if (!ok) return NotFound();
            return NoContent();
        }

        // PATCH: api/airplanes/5/activate
        [HttpPatch("{id:int}/activate")]
        public IActionResult Activate(int id)
        {
            var ok = _service.Activate(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
