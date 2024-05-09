using trackmystuff.Models;
using trackmystuff.Data;

namespace trackmystuff.Controllers;

public class UserController
{
    //Object to do data access stuff with
    //we can not instatiate an object representation of an interface
    // we Can how ever create an object of a class that 
    private static IUserStorageRepo _userData = new JSONUserStorage();


    //This function will take input from presentation layer
    //It will then, create user object that we will eventually store
    //it will pass that created object to the data access layer
    public static void CreateUser(string userName)
    {
         
        User newUser = new User(userName);

        Console.WriteLine($"Userid: {newUser.userId}");
        Console.WriteLine($"User Name: {newUser.userName}");
        //call a data access fucntion to call a Data Access Layer method to store USER
        _userData.StoreUser(newUser);
    }

    //this function will eventually be used to check if a given username already exsists
    //in our data store
    public static bool UserExsists(string userName)
    {
//write some method in UserStorage.cs that can find a User if they already exsist

        
        if(_userData.FindUser(userName) !=null)
        {
            return true;
        }
        else return false;
    }

    public static User FindUserControl(string userNameToFind) 
    {
        User returnUser = new User();
        returnUser = _userData.FindUser(userNameToFind);
        return returnUser;
    }

}