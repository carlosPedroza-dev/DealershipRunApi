
namespace DealershipRun.AppHost.Car
{
    public interface ICarRepository
    {
        Task<List<CarEntity>> getAll();
        Task<CarEntity?> getById(long id);
        Task<CarEntity> createCar(CarEntity car);
        Task Update(CarEntity car);
        Task Delete(long id);
        Task UpdateStatus(long id, CarStatus status);
    }
}
