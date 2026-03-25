

using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DealershipRun.AppHost.Order
{
    public interface IOrderService
    {
        Task<OrderEntity> CreateOrder(long userId, long carId);
        Task<List<OrderEntity>> GetOrdersByUser(long userId);
        Task<OrderEntity?> GetById(long id);
        Task UpdateStatus(long id, OrderStatus status);
        Task CancelOrder(long orderId);
    }
}
