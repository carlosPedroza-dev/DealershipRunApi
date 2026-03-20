


using DealershipRun.AppHost.Car;
using DealershipRun.AppHost.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealershipRun.AppHost.Order
{
  
    public class OrderEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public long UserId { get; set; }
        [ForeignKey(nameof(User))]
        public UserEntity User { get; set; }
        [ForeignKey(nameof(Car))]
        public CarEntity Car { get; set; }
        [Required]
        public long CarId {  get; set; }
    }
}
