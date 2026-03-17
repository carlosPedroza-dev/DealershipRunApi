


using DealershipRun.AppHost.Order;
using System.ComponentModel.DataAnnotations;

namespace DealershipRun.AppHost.Car
{
    public class Car
    {
        [Key]
        private long id { get; set; }
        [Required]
        private string brand { get; set; }
        [Required]
        private string model { get; set; }
        private int year { get; set; }
        private decimal price { get; set; }
        private decimal mileage { get; set; }
        private CarStatus carStatus { get; set; }

        private List<OrderEntity> Orders { get; set; }


    }
}
