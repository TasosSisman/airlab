using AirLab.Models;
using Microsoft.EntityFrameworkCore;

namespace AirLab.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        public DbSet<PurpleAirData> PurpleAirData { get; set; }
        public DbSet<PurpleAirSensor> PurpleAirSensors { get; set; }
        public DbSet<ApplicationSetting> ApplicationSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PurpleAirSensor>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<ApplicationSetting>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<PurpleAirSensor>()
                .HasIndex(x => x.SensorId)
                .IsUnique();

            modelBuilder.Entity<PurpleAirSensor>()
                .Property(x => x.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<PurpleAirData>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<PurpleAirData>()
                .HasOne(x => x.Sensor)
                .WithMany(x => x.Data)
                .HasForeignKey(x => x.SensorId)
                .HasPrincipalKey(x => x.SensorId);

            modelBuilder.Entity<PurpleAirSensor>().HasData(new PurpleAirSensor()
            {
                Id = 1,
                SensorId = 129953,
                Name = "ENVICARE-18",
                LastSeen = DateTime.Now,
                Latitude = 37.978294d,
                Longitude = 23.672758d,
                Altitude = 65
            });
        }
    }
}
