using System.Timers;
using trackmystuff.Controllers;
using trackmystuff.Data;
using trackmystuff.Models;

namespace trackmystuff.presentation;

public class Menu
{

    //this method displasys the initial menu when user runs program
    public static void StartMenu()
    {

        int userChoice = 0;
        bool validInput = true;
        Console.WriteLine("Welcome to Track My Stuff");
        Console.WriteLine("1. New user.");
        Console.WriteLine("2. Returning user");
        Console.WriteLine("3. Exit program");

        do
        {
        try
        {
        userChoice = Convert.ToInt32(Console.ReadLine());
        
        validInput = true;
        switch(userChoice)
        {
            case 1:
            CreateUserMenu();
            break;
            case 2:
            
            UserSignin();
            break;
            case 3:
            
            return;
            default:
            Console.WriteLine("try another number");
            validInput = false;
            break;

        }
        }
        catch (Exception ex)
        {
            validInput = false;
            
            //Console.WriteLine(ex.Message);
            //Console.WriteLine(ex.StackTrace);
            Console.WriteLine("Please enter valid choice");
        }
        
        } while (!validInput);

    }
    // this method handles the propmts for creating a new user profile
    public static void CreateUserMenu()
    {
        //ask for USER name
        // check for null or empty
        // call controller's userExsists method to see if name is take
        //if it is taken prompt user to try again
        //Pass value to controller
        bool validInput = true;
        string userInput = "";
        do
        {
            Console.WriteLine("Enter User Name or Q to quit: ");
            userInput = Console.ReadLine().Trim()??"";
            if (userInput.ToLower() == "q")
            {return;}
            else
            {
            
            if (String.IsNullOrEmpty(userInput))
            {
                validInput=false;
                Console.WriteLine("Enter any value.");
            }
            else if(UserController.UserExsists(userInput)!= false)
            {
                Console.WriteLine("Username exists, try again");
                validInput =false;
            }
            else 
            {
                UserController.CreateUser(userInput);
                Console.WriteLine("Profile created");
                validInput = true;
            }
            }
        } while(!validInput);
        
    }

    public static void UserSignin()
    {
        Console.WriteLine("enter User Name:");
        User SignedInUser = UserStorage.FindUser(Console.ReadLine().Trim());
        if (SignedInUser !=null)
        {
        Console.WriteLine($"User ID: {SignedInUser.userId}");
        Console.WriteLine($"User name: {SignedInUser.userName}");
        }
        else{
            Console.WriteLine("User doesn't exsist");
        }
    }
    
}