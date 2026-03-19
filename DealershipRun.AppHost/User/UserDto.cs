


using DealershipRun.AppHost.Order;

namespace DealershipRun.AppHost.User
{
    public record UserDto(
        long Id,
        string Username,
        string Email,
        Role Role,
        List<OrderEntity> Orders
        );
}
