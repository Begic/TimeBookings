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

}