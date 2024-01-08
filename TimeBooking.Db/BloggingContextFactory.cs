using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TimeBooking.Db;

public class BloggingContextFactory
{
    private readonly IConfiguration config;

    public BloggingContextFactory(IConfiguration config)
    {
        this.config = config;
    }

    public DataBaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

        return new DataBaseContext(optionsBuilder.Options, config);
    }
}