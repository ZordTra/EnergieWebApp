using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EnergieWebApp.Models;

namespace EnergieWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<Mode> Modes { get; set; }
        public DbSet<DayData> DayDatas { get; set; }
        public DbSet<TypeDevice> TypeDevices { get; set; }
        public DbSet<Account> AccountDatas { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}