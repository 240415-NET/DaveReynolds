using Project1.Data;
using Project1.Models;
using Project1.Presentation;

namespace Project1.Controllers;

public class UserController
{
    //in order to change from JSON to SQL change below from JSON to Sql and viceversa
    public static IUserStorageRepo _userData = new SqlUserStorage();
    public static void CreateUser(string userName)
    {
        User newUser = new User(userName);
        //new user is passed to data handler to save to Json file
        _userData.StoreUser(newUser);
        Console.WriteLine("New User------");
        Console.WriteLine($"User ID: {newUser.userId}");
        Console.WriteLine($"User name: {newUser.name}");

    }


    public static bool UserExsists(string userName)
    {
        if (_userData.FindUser(userName) == null)
        {
            return false;
        }
        else { return true; }

    }

    public static User UserLogin(string userName)
    {
        return _userData.FindUser(userName);
    }

    public static List<User> ListUsers()
    {
        return _userData.ReturnUsersList();
    }


}