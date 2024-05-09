using Project1.Data;
using Project1.Models;
using Project1.Presentation;

namespace Project1.Controllers;

public class UserController
{
    public static IUserStorageRepo _userData = new JSONUserStorage();
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
        else return true;

    }

    public static User UserLogin(string userName)
    {
        return _userData.FindUser(userName);
    }


}