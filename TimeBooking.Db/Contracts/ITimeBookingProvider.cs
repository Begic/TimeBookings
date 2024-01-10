using TimeBooking.Db.Models;

namespace TimeBooking.Db.Contracts;

public interface ITimeBookingProvider
{
    Task<List<TimeBookingDayInfo>> GetAllTimeBookings();
}