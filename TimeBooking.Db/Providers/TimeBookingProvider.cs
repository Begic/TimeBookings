using Microsoft.EntityFrameworkCore;
using TimeBooking.Db.Contracts;
using TimeBooking.Db.Models;

namespace TimeBooking.Db.Providers;

public class TimeBookingProvider : ITimeBookingProvider
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public TimeBookingProvider(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }

    public async Task<List<TimeBookingDayInfo>> GetAllTimeBookings()
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);

        var result = await db.TimeBookingDays
            .Select(x=> new TimeBookingDayInfo
        {
            Id = x.Id,
            UserId = x.UserId,
            BookingDay = x.BookingDay,
            Remark = x.Remark,
            TimeBookingDetails = x.TimeBookingDetails.Select(y=> new TimeBookingDetailInfo
            {
                Id = y.Id,
                StartTime = y.StartTime,
                EndTime = y.EndTime,
                Remark = y.Remark,
            }).ToList()
        }).ToListAsync();

        return result;
    }
}