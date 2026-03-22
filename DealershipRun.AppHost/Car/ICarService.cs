

namespace DealershipRun.AppHost.Car
{
    public interface ICarService
    {
        Task<List<CarEntity>> getAll();
        Task<CarEntity?> getById(long id);
        Task<CarEntity> createCar(CarEntity car);
        Task Update(long id, CarEntity car);
        Task Delete(long id);
        Task UpdateStatus(long id, CarStatus status);

    }
}
