

using DealershipRun.AppHost.Exceptions;

namespace DealershipRun.AppHost.Car
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository) {
            _carRepository = carRepository;
        }
        
        public async Task<CarEntity> createCar(CarEntity car)
        {
            if (car.Price <= 0) { throw new BadRequestException("Price must be greater than 0"); }
            if (car.Year < 1900) {throw new BadRequestException("Invalid Year"); }
            return await _carRepository.createCar(car);
        }
        
        public async Task Delete(long id)
        {
            var car = await _carRepository.getById(id);
            if (car == null) {
                throw new NotFoundException($"Car with id {id} not found");
            }
            await _carRepository.Delete(id);
        }
        
        public async Task<List<CarEntity>> getAll()
        {
            return await _carRepository.getAll();
        }
        
        public async Task<CarEntity?> getById(long id)
        {
            var car = await _carRepository.getById(id);
            if (car == null) {
                throw new NotFoundException($"Car with id {id} not found");
            }
            return car;
        }

        public async Task Update(long id, CarEntity car)
        {
var existing = await _carRepository.getById(id);
            if (existing == null) { throw new NotFoundException($"Car with id {id} not found"); }
            existing.Brand = car.Brand;
            existing.Model = car.Model;
            existing.Year = car.Year;
            existing.Price = car.Price;
            existing.Mileage = car.Mileage;
            await _carRepository.Update(existing);
        }

        public async Task UpdateStatus(long id, CarStatus status)
        {
            var car = await _carRepository.getById(id);
            if (car == null) { throw new NotFoundException($"Car with id {id} not found");}
            await _carRepository.UpdateStatus(id, status);
        }
    }
}
