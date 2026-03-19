

using System.ComponentModel.DataAnnotations;

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
        [Required]
        public long CarId {  get; set; }
    }
}
