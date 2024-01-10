using Microsoft.EntityFrameworkCore;
using TimeBooking.Db.Contracts;

namespace TimeBooking.Db.Providers;

public class TimeBookingProvider : ITimeBookingProvider
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public TimeBookingProvider(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }

    public async Task<object> GetAllTimeBookings()
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);

        return null;
    }
}