


using DealershipRun.AppHost.Order;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealershipRun.AppHost.Car
{
    [Table("cars")]
    public class CarEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("brand")]
        public string Brand { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        [Column("model")]
        public string Model { get; set; } = string.Empty;
        [Required]
        [Column("year")]
        public int Year { get; set; }
        [Required]
        [Column("price")]
        public decimal Price { get; set; }
        [Required]
        [Column("mileage")]
        public decimal Mileage { get; set; }
        [Required]
        [Column("car_status")]
        public CarStatus CarStatus { get; set; }

        public List<OrderEntity> Orders { get; set; } = [];


    }
}
