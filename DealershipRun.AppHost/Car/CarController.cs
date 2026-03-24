

using Microsoft.AspNetCore.Mvc;

namespace DealershipRun.AppHost.Car
{
    [ApiController]
    [Route("DealershipRun/Cars")]
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
            var result = cars.Select(c => new CarDTO(
                c.Id, c.Brand, c.Model, c.Year, c.Price, c.Mileage, c.CarStatus
            ));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(long id) {
            var car = await _carService.getById(id);
            return Ok(car);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarDTO dto)
        {
            var car = new CarEntity
            {
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                Price = dto.Price,
                Mileage = dto.Milleage,
                CarStatus = CarStatus.Available
            };
            var created = await _carService.createCar(car);
            return CreatedAtAction(nameof(getById), new { id = created.Id }, new CarDTO(
                created.Id, created.Brand, created.Model, created.Year, created.Price, created.Mileage, created.CarStatus
            ));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] CarDTO dto)
        {
            var car = new CarEntity
            {
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                Price = dto.Price,
                Mileage = dto.Milleage
            };
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
