using Microsoft.EntityFrameworkCore;
using TimeBooking.Db.Contracts;
using TimeBooking.Db.Models;

namespace TimeBooking.Db.Providers;

public class UserProvider : IUserProvider
{
    private readonly IDbContextFactory<DataBaseContext> factory;

    public UserProvider(IDbContextFactory<DataBaseContext> factory)
    {
        this.factory = factory;
    }

    public async Task<List<UserInfo>> GetAllUserInfos()
    {
        await using var db = await factory.CreateDbContextAsync().ConfigureAwait(false);

        return await db.Users.Select(x => new UserInfo
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Birthday = x.Birthday,
            Email = x.Email
        }).ToListAsync();
    }
}