using TimeBooking.Db.Models;

namespace TimeBooking.Db.Contracts;

public interface ITimeBookingDetailProvider
{
    Task StampOut(UserInfo? currentUser);
    Task StampIn(UserInfo? currentUser);
}