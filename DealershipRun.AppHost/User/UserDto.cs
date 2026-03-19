


using DealershipRun.AppHost.Order;

namespace DealershipRun.AppHost.User
{
    public record UserDto(
        long Id,
        DateTime OrderDate,
        decimal TotalAmount,
        OrderStatus Status,
        long UserId,
        long CarId
        );
}
