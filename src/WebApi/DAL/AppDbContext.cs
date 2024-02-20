using Microsoft.EntityFrameworkCore;

namespace WebApi.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<WeatherDbModel> WeatherArchives {  get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var builder = modelBuilder.Entity<WeatherDbModel>();
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.City)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.TemperatureC)
                .HasDefaultValue(0);

            builder.HasIndex(x => x.Id);
            builder.HasIndex(x => x.Date);
            builder.HasIndex(x => x.City);
        }
    }
}
