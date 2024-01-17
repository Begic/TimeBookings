using Microsoft.EntityFrameworkCore;
using TimeBooking.Db.Contracts;
using TimeBooking.Db.Entities;
using TimeBooking.Db.Models;

namespace TimeBooking.Db.Providers;

public class TimeBookingDetailProvider : ITimeBookingDetailProvider
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public TimeBookingDetailProvider(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }

    public async Task StampIn(UserInfo? currentUser, int? bookingDayId = null)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        
        var toStampIn = await db.TimeBookingDays
            .Include(x => x.TimeBookingDetails)
            .FirstOrDefaultAsync(x => x.BookingDay == DateTime.Today);

        if (toStampIn != null && toStampIn.TimeBookingDetails != null)
        {
            toStampIn.TimeBookingDetails.Add(new TimeBookingDetail
            {
                StartTime = DateTime.Now,
            });
        }

        await db.SaveChangesAsync();
    }

    public async Task StampOut(UserInfo? currentUser, int? bookingDayId = null)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);

        var toStampOut = await db.TimeBookingDays
            .Include(x => x.TimeBookingDetails)
            .FirstOrDefaultAsync(x => x.BookingDay == DateTime.Today);
        
        if (toStampOut != null && toStampOut.TimeBookingDetails != null)
        {
            var toEdit = toStampOut.TimeBookingDetails.FirstOrDefault(x => x.EndTime == null);
            
            toEdit.EndTime = DateTime.Now;
        }

        await db.SaveChangesAsync();
    }

    public async Task DeleteTimeStamping(int bookingDetailId)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);

        var doDelete = await db.TimeBookingDetails.FirstOrDefaultAsync().ConfigureAwait(false);
        if (doDelete != null)
        {
            db.TimeBookingDetails.Remove(doDelete);
        }

        await db.SaveChangesAsync();
    }
}