using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

public interface IUserStorageEFRepo
{
    public Task<User?> CreateUserinDBAsync(User userSentFromUserService);
    public Task<User?> GetUserFromDBUsernameAsync(string usernameToFindFromUserService);
    public Task<bool> DoesThisUserExsistOnDBAsync( string usernameToFindUserService);
    public void DeleteUserfromDBAsync(string usernameToDeleteFromUserService);
    

}