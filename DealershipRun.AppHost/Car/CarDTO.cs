

using DealershipRun.AppHost.Order;

namespace DealershipRun.AppHost.Car
{
     public record CarDTO(
         long Id,
         string Brand,
         string Model,
         int Year,
         decimal Price,
         decimal Milleage,
         CarStatus Status
         );
}
