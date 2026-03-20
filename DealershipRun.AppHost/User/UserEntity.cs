

using DealershipRun.AppHost.Order;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DealershipRun.AppHost.User
{
    [Table("users")]
    public class UserEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("user_name")]
        public string UserName { get; set; } = string.Empty;
        [Column("email")]
        [Required]
        [EmailAddress]
        [MaxLength(50)]

        public string Email { get; set; } = string.Empty;
        [Required]
        [JsonIgnore]
        [MaxLength(60)]
        public string PasswordHash { get; set; } = string.Empty;


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Role Role { get; set; }
        public List<OrderEntity> Orders { get; set; } = [];

    }
}
