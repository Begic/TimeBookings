using TimeBooking.Db.Models;

namespace TimeBooking.Db.Contracts;

public interface IUserProvider
{
    Task<List<UserInfo>> GetAllUserInfos();
}