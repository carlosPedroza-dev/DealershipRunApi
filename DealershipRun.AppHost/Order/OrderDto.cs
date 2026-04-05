

namespace DealershipRun.AppHost.Order
{
    public record OrderDTO(
        long Id,
        DateTime OrderDate,
        decimal TotalAmount,
        OrderStatus Status,
        long UserId,
        long CarId
        );
}
