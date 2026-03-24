

using Microsoft.AspNetCore.Mvc;

namespace DealershipRun.AppHost.Car
{
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService) {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var cars = await _carService.getAll();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(long id) {
            var car = await _carService.getById(id);
            return Ok(car);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarEntity car)
        {
            var created = await _carService.createCar(car);
            return CreatedAtAction(nameof(getById), new { id = created.Id }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] CarEntity car)
        {
            await _carService.Update(id, car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _carService.Delete(id);
            return NoContent();
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(long id, [FromBody] CarStatus status)
        {
            await _carService.UpdateStatus(id, status);
            return NoContent();
        }
    }
}
