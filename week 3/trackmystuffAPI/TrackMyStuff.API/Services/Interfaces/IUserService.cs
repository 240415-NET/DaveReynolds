using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Services;

public interface IUserService
{
    public async Task<User> CreateNewUserAsync(User newUserFromController);
}