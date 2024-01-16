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
        var toEdit = await db.TimeBookingDays
            .Include(x=> x.TimeBookingDetails)
            .FirstOrDefaultAsync(x => x.Id == editModel.Id);

        if (toEdit == null)
        {
            await db.TimeBookingDays.AddAsync( toEdit = new TimeBookingDay());
        }

        toEdit.BookingDay = editModel.BookingDay.Value;
        toEdit.UserId = currentUser.Id;
        toEdit.Remark = editModel.Remark;

        // TODO
        
        await db.SaveChangesAsync();
    }
    
    public async Task DeleteTimeBookingDay(int timeBookingId)
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);
        
        var doDelete = await db.TimeBookingDays.FirstOrDefaultAsync(x=> x.Id == timeBookingId).ConfigureAwait(false);
        if (doDelete != null)
        {
            db.TimeBookingDays.Remove(doDelete);
        }
        
        await db.SaveChangesAsync();
    }
}