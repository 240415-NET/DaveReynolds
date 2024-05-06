using trackmystuff.Models;
using trackmystuff.Data;
namespace trackmystuff.Controllers;

public class UserController
{

    //This function will take input from presentation layer
    //It will then, create user object that we will eventually store
    //it will pass that created object to the data access layer
    public static void CreateUser(string userName)
    {
         
        User newUser = new User(userName);

        Console.WriteLine($"Userid: {newUser.userId}");
        Console.WriteLine($"User Name: {newUser.userName}");
        //call a data access fucntion to call a Data Access Layer method to store USER
        UserStorage.StoreUser(newUser);
    }

    //this function will eventually be used to check if a given username already exsists
    //in our data store
    public static bool UserExsists(string userName)
    {
//write some method in UserStorage.cs that can find a User if they already exsist

        
        if(UserStorage.FindUser(userName) !=null)
        {
            return true;
        }
        else return false;
    }

}