using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EnergieWebApp.Models;

namespace EnergieWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<DayData> DayDatas { get; set; }
        public DbSet<TypeDevice> TypeDevices { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HouseholdDevice> HouseholdDevices { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship between Household and Device
            modelBuilder.Entity<HouseholdDevice>()
                .HasKey(hd => new { hd.HouseholdId, hd.DeviceId });

            modelBuilder.Entity<HouseholdDevice>()
                .HasOne(hd => hd.Household)
                .WithMany(h => h.HouseholdDevices)
                .HasForeignKey(hd => hd.HouseholdId);

            modelBuilder.Entity<HouseholdDevice>()
                .HasOne(hd => hd.Device)
                .WithMany(d => d.HouseholdDevices)
                .HasForeignKey(hd => hd.DeviceId);
        }


    }
}