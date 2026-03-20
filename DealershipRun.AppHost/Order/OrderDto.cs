using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
