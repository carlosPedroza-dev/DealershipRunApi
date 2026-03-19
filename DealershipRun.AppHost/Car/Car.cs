


using DealershipRun.AppHost.Order;
using System.ComponentModel.DataAnnotations;

namespace DealershipRun.AppHost.Car
{
    public class Car
    {
        [Key]
        private long Id { get; set; }
        [Required]
        private string Brand { get; set; }
        [Required]
        private string Model { get; set; }
        private int Year { get; set; }
        private decimal Price { get; set; }
        private decimal Mileage { get; set; }
        private CarStatus CarStatus { get; set; }

        private List<OrderEntity> Orders { get; set; }


    }
}
