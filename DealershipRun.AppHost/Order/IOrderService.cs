

using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DealershipRun.AppHost.Order
{
    public interface IOrderService
    {
        Task createOrder(long userId, long carId);
        Task getOrdersByUser(long userId);
        Task<OrderEntity> GetById(long id);
        Task updateStatus(long id, OrderStatus status);
        Task cancelOrder(long orderId);
    }
}
