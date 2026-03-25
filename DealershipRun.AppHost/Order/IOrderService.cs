

using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DealershipRun.AppHost.Order
{
    public interface IOrderService
    {
        Task  CreateOrder(long userId, long carId);
        Task GetOrdersByUser(long userId);
        Task<OrderEntity> GetById(long id);
        Task UpdateStatus(long id, OrderStatus status);
        Task CancelOrder(long orderId);
    }
}
