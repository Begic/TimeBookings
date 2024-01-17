using Microsoft.EntityFrameworkCore;
using TimeBooking.Db.Contracts;
using TimeBooking.Db.Entities;
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
            .Select(x => new TimeBookingDayInfo
            {
                Id = x.Id,
                UserId = x.UserId,
                BookingDay = x.BookingDay,
                Remark = x.Remark,
                TimeBookingDetails = x.TimeBookingDetails.Select(y => new TimeBookingDetailInfo
                {
                    Id = y.Id,
                    StartTime = y.StartTime,
                    EndTime = y.EndTime,
                    Remark = y.Remark,
                }).ToList()
            }).ToListAsync();

        return result;
    }

    public async Task AddTimeBookingDay(UserInfo? currentUser, EditTimeBookingDay editModel)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);

        await db.TimeBookingDays.AddAsync(new TimeBookingDay
        {
            BookingDay = DateTime.Today,
            UserId = currentUser.Id,
            TimeBookingDetails = new List<TimeBookingDetail>(new[]
            {
                new TimeBookingDetail
                {
                    StartTime = DateTime.Now
                }
            })
        });

        await db.SaveChangesAsync();
    }

    public async Task DeleteTimeBookingDay(int timeBookingId)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        var doDelete = await db.TimeBookingDays.FirstOrDefaultAsync(x => x.Id == timeBookingId).ConfigureAwait(false);
        if (doDelete != null)
        {
            db.TimeBookingDays.Remove(doDelete);
        }

        await db.SaveChangesAsync();
    }

    public async Task<EditTimeBookingDay> GetFreshEditData(int timeBookingIdDayId)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        return await db.TimeBookingDays.Where(x => x.Id == timeBookingIdDayId)
            .Select(x => new EditTimeBookingDay
            {
                Id = x.Id,
                BookingDay = x.BookingDay,
                Remark = x.Remark,
                TimeBookingDetails = x.TimeBookingDetails.Select(y=> new EditTimeBookingDetail
                {
                    Id = y.Id,
                    StartTime = y.StartTime.TimeOfDay,
                    EndTime = y.EndTime.Value.TimeOfDay,
                    Remark = y.Remark,
                    BookingDate = y.StartTime.Date
                }).ToList()
            }).FirstOrDefaultAsync();
    }
}