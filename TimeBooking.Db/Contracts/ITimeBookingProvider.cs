namespace TimeBooking.Db.Contracts;

public interface ITimeBookingProvider
{
    Task<object> GetAllTimeBookings();
}