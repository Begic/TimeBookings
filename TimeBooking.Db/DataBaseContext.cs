using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TimeBooking.Db.Entities;

namespace TimeBooking.Db;

public class DataBaseContext : DbContext
{
    private readonly IConfiguration config;

    public DbSet<User> Users { get; set; }
    public DbSet<TimeBookingDay> TimeBookingDays { get; set; }
    public DbSet<TimeBookingDetail> TimeBookingDetails { get; set; }

    internal DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
    {
        
    }
    
    public DataBaseContext(DbContextOptions<DataBaseContext> options, IConfiguration config) : base(options)
    {
        this.config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    }
}