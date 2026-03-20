


using DealershipRun.AppHost.Car;
using DealershipRun.AppHost.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealershipRun.AppHost.Order
{

    [Table("order")]
    public class OrderEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Column("order_time")]
        public DateTime OrderTime { get; set; }
        [Required]
        [Column("total_amount")]
        public decimal TotalAmount { get; set; }
        [Required]
        [Column("status")]
        public OrderStatus Status { get; set; }
        [Required]
        [Column("user_id")]
        public long UserId { get; set; }
        [ForeignKey(nameof(User))]
        public UserEntity User { get; set; }
        [ForeignKey(nameof(Car))]
        public CarEntity Car { get; set; }
        [Required]
        [Column("car_id")]
        public long CarId {  get; set; }
    }
}
