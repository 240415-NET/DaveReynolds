using Microsoft.AspNetCore.Http.HttpResults;
using TrackMyStuff.API.Controllers;
using TrackMyStuff.API.Models;
using TrackMyStuff.API.Data;

namespace TrackMyStuff.API.Services;

public class UserService : IUserService
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
        if (await UserExistsAsync(newUserFromController.userName))
        {
            //if user names exists we will manually throw a exception
            throw new Exception("User already exists");
        }
        if (string.IsNullOrEmpty(newUserFromController.userName))
        {
            throw new Exception("User name can not be blank");
        }

        await _userStorage.CreateUserinDBAsync(newUserFromController);

        //if this all goes smooth and call the method in the data access layer 
        //we will just echo back user info passed in
        return newUserFromController;

    }

    public async Task<User> GetUserByUserNameAsync(string userNameToFindFromController)
    {

        //here we check if front end empty or null string and if true throw error and do not go to data access
        if (String.IsNullOrEmpty(userNameToFindFromController))
        {
            throw new Exception("Cannot pass in a null or empty string");
        }

//here we call Data access , wrapped in a try catch so we don't crash API for a no match
        try
        {
            //creating a user object in order to check if user is found before returning to controller

           User? foundUser= await _userStorage.GetUserFromDBUsernameAsync(userNameToFindFromController);
           
            //if our data access layer's call doesn't find a user based on username it will return a null
            //if that value is null we throw exception
           if (foundUser!=null)
           {
            throw new Exception("Username not found in DB");
           }
           return foundUser;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }


    }

    public async Task<bool> UserExistsAsync(string userNameToFindFromController)
    {
        return await _userStorage.DoesThisUserExsistOnDBAsync(userNameToFindFromController);
    }

    public async void DeleteUserByUsernameAsync(string userNameToDeleteFromController)
    {
        //lets leverage userexsistsAysnc
        //if user exsists we delete it 
        if (await UserExistsAsync(userNameToDeleteFromController)== true)
        {
            _userStorage.DeleteUserfromDBAsync(userNameToDeleteFromController);
        }
        else
        {
            throw new Exception("User does not exsists can't be deleted");
        }
        //if not , we throw an executution to enter controlers cath
    }


}