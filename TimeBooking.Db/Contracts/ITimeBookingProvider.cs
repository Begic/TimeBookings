using TimeBooking.Db.Models;

namespace TimeBooking.Db.Contracts;

public interface ITimeBookingProvider
{
    Task<List<TimeBookingDayInfo>> GetAllTimeBookings();
    Task AddTimeBookingDay(UserInfo? currentUser, EditTimeBookingDay editModel);
    Task StampOut();
}