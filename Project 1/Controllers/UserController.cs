using Project1.Data;
using Project1.Models;
using Project1.Presentation;

namespace Project1.Controllers;

public class UserController
{
    public static void CreateUser(string userName)
    {
        User newUser = new User(userName);
        //new user is passed to data handler to save to Json file
        UserStorage.StoreUser(newUser);
        Console.WriteLine("New User------");
        Console.WriteLine($"User ID: {newUser.userId}");
        Console.WriteLine($"User name: {newUser.name}");
    
    }

    
    public static bool UserExsists(string userName)
    {
        if (UserStorage.FindUser(userName) == null)
        {
            return false;
        }
        else return true;

    }

    

}