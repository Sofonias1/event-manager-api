using Microsoft.EntityFrameworkCore;

using EventManager.API.Domain.Models;

namespace EventManager.API.Persistence.Contexts
{
    //a class EF Core uses to map your models to database tables.
    public class AppDbContext : DbContext
    {
        public DbSet<Organizer> Organizers {get; set;}
        public DbSet<Event> Events {get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Organizer>().ToTable("Organizers");
            builder.Entity<Organizer>().HasKey(p => p.Id); // Set Primary key
            builder.Entity<Organizer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd(); // “fluent way” (chaining methods).
            builder.Entity<Organizer>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Organizer>().HasMany(p => p.Events).WithOne(p => p.organizer).HasForeignKey(p => p.OrganizerId);
            
            
            // Data seeding
            builder.Entity<Organizer>().HasData(
                new Organizer {Id= 100, Name="John Smith", Email="John@gmail.com", Web="John.com", Location="Redmond,WA"},
                new Organizer {Id= 101, Name="Mike Alna", Email="Mike@gmail.com", Web="Mike.com", Location="Richmond,VA"},
                new Organizer {Id= 102, Name="Rick Smith", Email="Rick@gmail.com", Web="Rick.com", Location="Durham,NC"},
                new Organizer {Id= 103, Name="Roger Camp", Email="Roger@gmail.com", Web="Roger.com", Location="LosAngles,CA"}
            ); 

            builder.Entity<Event>().ToTable("Events");
            builder.Entity<Event>().HasKey(p => p.Id);
            builder.Entity<Event>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Event>().Property(p => p.Title).IsRequired().HasMaxLength(60);

            builder.Entity<Event>().HasData(
                new Event {Id=200, Title="Diwali Family Festival", Description="Festival", LocationName="Art Museum", Address="1300 1st Ave", City="Seattle", Country="US", StartTimeInUTC="2019-11-16T11:00:00", EndTimeInUTC="2019-11-16T14:00:00", Type=Enums.EventTypes.Festivals, OrganizerId=100},
                new Event {Id=201, Title="Bea Miller, Kah-Lo, Kennedi", Description="Music", LocationName="ShowBox", Address="1426 1st Ave", City="Seattle", Country="US", StartTimeInUTC="2019-11-12T20:00:00", EndTimeInUTC="2019-11-13T01:00:00", Type=Enums.EventTypes.Parties, OrganizerId=101},
                new Event {Id=202, Title="VineArts", Description="Art Show", LocationName="Garden and Glass", Address="305 Harrison St", City="Seattle", Country="US", StartTimeInUTC="2019-11-14T12:30:00", EndTimeInUTC="2019-11-13T20:30:00", Type=Enums.EventTypes.Socials, OrganizerId=102}
            ); 
            
        }
    }
}