using TrackMyStuff.API.Models;
using TrackMyStuff.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace TrackMyStuff.API.Data;

public class UserStorageEFRepo : IUserStorageEFRepo
{
    //this holds our context object tha
    private readonly TrackMyStuffContext _context;
    public UserStorageEFRepo(TrackMyStuffContext contextFromBuilder)
    {
        _context = contextFromBuilder;
    }
    public async Task<User?> CreateUserinDBAsync(User newUserSentFromUserService)
    {
        //first we use the context object, reference the table to add to, then use .add to stage add
        _context.Users.Add(newUserSentFromUserService);

        //we can .Add as much as we want but nothing will save until .SaveChanges is run 
         //this line acutally adds saves to database
         await _context.SaveChangesAsync();

     return newUserSentFromUserService; 
    }

    public async Task<User?> GetUserFromDBUsernameAsync(string usernameToFindFromUserService)
    {

        //trying to find user based on user name string passed in using LINQ
        //in this method call, we use LINQ fo a single user base on username matching the user name passed in
        User? foundUser = await _context.Users.SingleOrDefaultAsync(user => user.userName == usernameToFindFromUserService);
// returning either the user or null to the service layer
        return foundUser;


    }
    //new method using .Any LINQ method to check if a user exsists on our DB
    // this method will return a boolean, it does tno care about returning any sort of user object

    public async Task<bool> DoesThisUserExsistOnDBAsync( string usernameToFindUserService)
    {
        //will call .any() which returns boolean
        return await _context.Users.AnyAsync(user => user.userName == usernameToFindUserService);
    }

    public async void DeleteUserfromDBAsync(string usernameToDeleteFromUserService)
    {
        //we know that we have already checked if user exists so once this method is called we will be deleteing someone
        //we call the .Remove() EFCore method, to remove the user object passed into it from the database
        
        User userToDelete = await GetUserFromDBUsernameAsync(usernameToDeleteFromUserService);
        
        _context.Users.Remove(userToDelete);

        //then we need to save changes

         await _context.SaveChangesAsync();
    }
}