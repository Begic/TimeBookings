using TimeBooking.Db.Models;

namespace TimeBooking.Db.Contracts;

public interface ITimeBookingDetailProvider
{
    Task StampOut(UserInfo? currentUser, int editModelId);
    Task StampIn(UserInfo? currentUser, int editModelId);
}