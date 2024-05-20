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

        while (!exit)
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
                    switch (userChoice)
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
                catch (Exception ex)
                {
                    validInput = false;

                    //Console.WriteLine(ex.Message);
                    //Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Please enter valid choice");
                }
            } while (!validInput);
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

            if (userInput.ToLower() == "q")
            {
                Console.Clear();
                return;
            }


            if (String.IsNullOrEmpty(userInput))
            {
                validInput = false;
                Console.WriteLine("Enter a value");
            }
            else if (UserController.UserExsists(userInput))
            {
                Console.WriteLine("Username exsists, try again");
                validInput = false;
            }
            else
            {
                UserController.CreateUser(userInput);
                Console.WriteLine("Profile created \nPress any key");
                Console.ReadLine();
                validInput = true;
            }
        } while (!validInput);
    }

    public static void UserSignin()
    {

        Console.WriteLine("Enter Username or Q to go back: ");
        string userInput = Console.ReadLine().Trim();

        if (userInput.ToLower() == "q")
        {
            Console.Clear();
            return;
        }

        User signedInUser = UserController.UserLogin(userInput);
        if (signedInUser != null)
        {
            Console.WriteLine($"User Name: {signedInUser.name}");
            Console.WriteLine($"User ID: {signedInUser.userId}");

            CardMenu(signedInUser);
            //eventually go to a sub menu with options
            //1. Add cards
            //2. Remove cards
            //3. view cards
            //4. trade cards?

        }
        else
        {
            Console.WriteLine("User not found! Do you need to create a new user?");
            userInput = Console.ReadLine().Trim();
            if (userInput.ToLower() == "yes" || userInput.ToLower() == "y")
            {
                Menu.CreateUserMenu();
            }
            else
            {
                Console.WriteLine("User not found returning to main menu");
            }

        }


    }
    public static void CardMenu(User signedInUser)
    {
        Console.Clear();
        int userChoice = 0;
        bool validInput = true;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine($"{signedInUser.name}, what would you like to do?");
            Console.WriteLine("1. Add Cards");
            Console.WriteLine("2. Remove Cards");
            Console.WriteLine("3. View Cards");
            Console.WriteLine("4. Trade Cards");
            Console.WriteLine("5. Go Back");

            do
            {

                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                    validInput = true;
                    switch (userChoice)
                    {
                        case 1:
                            CardInput.CreateCardMenu(signedInUser);
                            break;
                        case 2:
                            Console.WriteLine("Remove cards");
                            break;
                        case 3:
                            CardView.CardViewMainMenu(signedInUser);
                            
                            break;
                        case 4:
                            Console.WriteLine("Trade cards");
                            break;

                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Try another number");
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
        }Console.Clear();

    }

}
