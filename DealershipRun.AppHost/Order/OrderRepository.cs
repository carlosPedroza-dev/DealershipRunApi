

using DealershipRun.AppHost.Data;
using Microsoft.EntityFrameworkCore;

namespace DealershipRun.AppHost.Order
{
    public class OrderRepository:IOrderRepository
    {
        private readonly DealershipRunDBcontext _context;

        public OrderRepository(DealershipRunDBcontext context)
        {
            _context = context;
        }

        
        public async Task CancelOrder(long orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if(order == null)
            {
                order.Status = OrderStatus.CANCELLED;
                await _context.SaveChangesAsync();
            }
        }

        public async Task <OrderEntity> CreateOrder(long userId, long carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            var order = new OrderEntity
            {
                UserId = userId,
                CarId = carId,
                OrderTime = DateTime.UtcNow,
                TotalAmount = car!.Price,
                Status = OrderStatus.PENDING
            };
            _context.Orders.Add(order); 
            await _context.SaveChangesAsync();
            return order;
        }

        public  async Task<OrderEntity?> GetById(long id)
        {
            return await _context.Orders
                .Include(o => o.UserId)
                .Include(o => o.CarId)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<OrderEntity>> GetOrdersByUser(long userId)
        {
            return await _context.Orders
                .Include(o => o.Car)
                .Include(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task UpdateStatus(long id, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(id);
            if(order == null)
            {
                order.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        
    }
}
