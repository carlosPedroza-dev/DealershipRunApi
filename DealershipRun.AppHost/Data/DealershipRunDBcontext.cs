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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<CarEntity>()
                .Property(c => c.CarStatus)
                .HasConversion<string>();

            modelBuilder.Entity<OrderEntity>()
                .Property(o => o.Status)
                .HasConversion<string>();
        }
    }
    }
