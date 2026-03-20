using DealershipRun.AppHost.Car;
using DealershipRun.AppHost.Order;
using DealershipRun.AppHost.User;
using Microsoft.EntityFrameworkCore;


namespace DealershipRun.AppHost.Data
{
    public class DealershipRunDBcontext : DbContext
    {
        public DealershipRunDBcontext(DbContextOptions<DealershipRunDBcontext> options)  
        :base(options){ }

        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        }
    }
