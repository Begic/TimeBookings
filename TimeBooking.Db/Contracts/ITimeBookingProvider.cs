using TimeBooking.Db.Models;

namespace TimeBooking.Db.Contracts;

public interface ITimeBookingProvider
{
    Task<List<TimeBookingDayInfo>> GetAllTimeBookings();
    Task AddTimeBookingDay(UserInfo? currentUser, EditTimeBookingDay editModel);
    Task DeleteTimeBookingDay(int timeBookingId);
    Task<EditTimeBookingDay> GetFreshEditData(int timeBookingIdDayId);
}