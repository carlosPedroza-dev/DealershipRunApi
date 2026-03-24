

using DealershipRun.AppHost.Data;
using Microsoft.EntityFrameworkCore;

namespace DealershipRun.AppHost.Car
{
    public class CarRepository : ICarRepository
    {
        private readonly DealershipRunDBcontext _context;

        public CarRepository(DealershipRunDBcontext context)
        {
            _context = context;
        }
        //Done
        public async Task<CarEntity> createCar(CarEntity car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
        //Done
        public async Task Delete(long id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null) {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

        //Done
        public async Task<List<CarEntity>> getAll()
        {
            return await _context.Cars.ToListAsync();
        }
        //Done
        public async Task<CarEntity?> getById(long id)
        {
            return await _context.Cars.FindAsync(id);
        }
        //Done
        public async Task Update( CarEntity car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            
            }
        
        //Done
        public async Task UpdateStatus(long id, CarStatus status)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null) {
                car.CarStatus = status;
                await _context.SaveChangesAsync();
                 
            }
        }
    }
}
