using Microsoft.AspNetCore.Http.HttpResults;
using TrackMyStuff.API.Controllers;
using TrackMyStuff.API.Models;
using TrackMyStuff.API.Data;

namespace TrackMyStuff.API.Services;

public class UserService :IUserService
{
    //The same way that our UserService is given to UserController via DI
    //we nee somtheing to store our data access object for database operations related to User model
    //again, we will create private readonly objects we don't create using new anywhere in this class

    private readonly IUserStorageEFRepo _userStorage;

    public UserService(IUserStorageEFRepo efRepoFromBuilder)
    {
        _userStorage = efRepoFromBuilder;
    }

    //This method will hold the business logic we decide on for creating new user
    //called by user controller's PostNewUser() method and with then call our IUserStorageEFRepo method
    //sticking the new user into database

    public async Task<User> CreateNewUserAsync(User newUserFromController)
    {
        //our rules for being able to create a new user
        //1. no dublicate names
        //2. not blank
        //we can throw specific exceptions here, that can trigger different try blocks in UserControl

        //call data access before creating new user to check for exisitng User names
        if (UserExists(newUserFromController.userName))
        {
            //if user names exists we will manually throw a exception
            throw new Exception("User already exists");
        }
        if(string.IsNullOrEmpty(newUserFromController.userName))
        {
            throw new Exception("User name can not be blank");
        }
        
        await _userStorage.CreateUserinDBAsync(newUserFromController);

        //if this all goes smooth and call the method in the data access layer 
        //we will just echo back user info passed in
        return newUserFromController;

    }

    public bool UserExists(string userName)
    {
        return false;
    } 
}