

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
        [Column("password_hash")]
        [Required]
        [JsonIgnore]
        [MaxLength(60)]
        public string PasswordHash { get; set; } = string.Empty;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("role")]
        public Role Role { get; set; }
        public List<OrderEntity> Orders { get; set; } = [];

    }
}
