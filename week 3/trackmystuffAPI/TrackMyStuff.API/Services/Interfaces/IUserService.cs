using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Services;

public interface IUserService
{
    public Task<User> CreateNewUserAsync(User newUserFromController);
    public Task<User> GetUserByUserNameAsync(string userNameToFindFromController);
     public void DeleteUserByUsernameAsync(string userNameToDeleteFromController);
}