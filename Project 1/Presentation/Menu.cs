using Project1.Controllers;
using Project1.Data;
using Project1.Models;

namespace Project1.Presentation;

public class Menu
{

    public static void StartMenu()
    {
        int userChoice = 0;
        bool validInput = true;
        bool exit = false;
        
        while(!exit)
        {
            Console.WriteLine("Welcome Please Select from Below:");
            Console.WriteLine("1. New User");
            Console.WriteLine("2. Exsisting User");
            Console.WriteLine("3. Exit");
                
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
                        exit = true;
                        break;
                        default:
                        Console.WriteLine("Try another number");
                        validInput = false;
                        break;

                    }
                }
                catch(Exception ex)
                {
                    validInput = false;

                    //Console.WriteLine(ex.Message);
                    //Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Please enter valid choice");
                }
            }while(!validInput);
        }
    }
    public static void CreateUserMenu()
    {

        bool validInput = true;
        string userInput = "";
        do
        {
            Console.WriteLine("Enter Name or Q to go back: ");
            userInput = Console.ReadLine().Trim();
            
            if(userInput.ToLower() == "q")
                {
                Console.Clear();
                return;
                }
            
            
            if (String.IsNullOrEmpty(userInput))
            {
                validInput = false;
                Console.WriteLine("Enter a value");
            }
            else if(UserController.UserExsists(userInput))
            {
                Console.WriteLine("Username exsists, try again");
                validInput = false;
            }
            else
            {
                UserController.CreateUser(userInput);
                Console.WriteLine("Profile created");
                validInput = true;
            }
        }while (!validInput);
    }

    public static void UserSignin()
    {

        Console.WriteLine("Enter Username or Q to go back: ");
        string userInput = Console.ReadLine().Trim();

        if(userInput.ToLower() == "q")
        {
            Console.Clear();
            return;
        }
        
        User signedInUser = UserStorage.FindUser(userInput);
        if (signedInUser !=null)
        {
            Console.WriteLine($"User Name: {signedInUser.name}");
            Console.WriteLine($"User ID: {signedInUser.userId}");

            //eventually go to a sub menu with options
            //1. Add cards
            //2. Remove cards
            //3. view cards
            //4. trade cards?
            
        }
        else
        {
            Console.WriteLine("User not found! Do you need to create a new user?");
            userInput =  Console.ReadLine().Trim();
            if (userInput.ToLower() == "yes" || userInput.ToLower() =="y")
            {
                Menu.CreateUserMenu();
            }
            else
            {
                Console.WriteLine("User not found returning to main menu");            
            }
        
        }

    
    }
}