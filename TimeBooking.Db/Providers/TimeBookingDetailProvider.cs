using Microsoft.EntityFrameworkCore;
using TimeBooking.Db.Contracts;
using TimeBooking.Db.Models;

namespace TimeBooking.Db.Providers;

public class TimeBookingDetailProvider : ITimeBookingDetailProvider
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public TimeBookingDetailProvider(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }
    
    public async Task StampOut(UserInfo? currentUser)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        var toStampOut = await db.TimeBookingDays
            .Include(x=> x.TimeBookingDetails)
            .FirstOrDefaultAsync(x => x.BookingDay == DateTime.Today);
        
        
    }

    public async Task StampIn(UserInfo? currentUser)
    {
        
    }
}