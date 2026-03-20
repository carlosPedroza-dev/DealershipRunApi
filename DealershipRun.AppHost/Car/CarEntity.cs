


using DealershipRun.AppHost.Order;
using System.ComponentModel.DataAnnotations;

namespace DealershipRun.AppHost.Car
{
    public class CarEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Mileage { get; set; }
        [Required]
        public CarStatus CarStatus { get; set; }

        public List<OrderEntity> Orders { get; set; } = [];


    }
}
