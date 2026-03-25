
using DealershipRun.AppHost.Exceptions;

namespace DealershipRun.AppHost.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CancelOrder(long orderId)
        {
            var order = await _orderRepository.GetById(orderId);
            if(order == null) { throw new NotFoundException($"order with id {orderId} not found"); }
            if (order.Status == OrderStatus.COMPLETED) { throw new BadRequestException("Cannot cancel a completed order"); }
            await _orderRepository.CancelOrder(orderId); 
        }

        public async Task<OrderEntity> CreateOrder(long userId, long carId)
        {
            return await _orderRepository.CreateOrder(userId, carId);
        }

        public async Task<OrderEntity?> GetById(long id)
        {
            var order = await _orderRepository.GetById(id); 
            if(order == null)
            {
                throw new NotFoundException($"Order with id {id} not found");
            }
            return order;
        }

        public async Task<List<OrderEntity>> GetOrdersByUser(long userId)
        {
            var orders = await _orderRepository.GetOrdersByUser(userId);
            if(orders.Count == 0)
            {
                throw new NotFoundException($"No orders found from user");
            }
            return orders;
        }

        public async Task UpdateStatus(long id, OrderStatus status)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null)
            {
                throw new NotFoundException($"Order with id {id} not found");
            }
            await _orderRepository.UpdateStatus(id, status);
        }

    }
}
