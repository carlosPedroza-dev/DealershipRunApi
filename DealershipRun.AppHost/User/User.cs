

using DealershipRun.AppHost.Order;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DealershipRun.AppHost.User
{
    [Table("users")]
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("email")]
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        
        public string Email { get; set; }
        [Required]
        [JsonIgnore]
        [MaxLength(20)]
        public string PasswordHash { get; set; }
        public List<OrderEntity> Orders{get;set;}
    }
}
