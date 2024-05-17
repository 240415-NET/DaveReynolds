using Project1.Controllers;
using Project1.Models;

namespace Project1.Presentation;


public class CardView
{
    public static void CardViewMainMenu(User signedInUser)

    {
        int userChoice = 0;
        bool validInput = true;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("What would you like to do");
            Console.WriteLine("1. View my cards");
            Console.WriteLine("2. View other user names");
            Console.WriteLine("3. View other Users cards");
            Console.WriteLine("4. Go Back");

            do
            {
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                    validInput = true;
                    switch (userChoice)
                    {
                        case 1:
                            CardViewTypeMenu(signedInUser);

                            //retrieve cards
                            break;
                        case 2:
                            Console.WriteLine("view other users");
                            //retrieve Users
                            break;
                        case 3:
                            Console.WriteLine("view other users cards");
                            //retrieve cards using other users
                            break;
                        case 4:
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

    public static void CardViewTypeMenu(User signedInUser)

    {
        int userChoice = 0;
        bool validInput = true;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine($"Which of {signedInUser.name}'s cards would you like to view?");
            Console.WriteLine("1. View Energy cards");
            Console.WriteLine("2. View Item cards");
            Console.WriteLine("3. View Monstercards");
            Console.WriteLine("4. View all cards");
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
                            //Retrive energy list
                            List<Energy> viewEnergy = CardController.ViewEnergy(signedInUser);
                            if (viewEnergy.Count() < 1)
                            {
                                Console.WriteLine("No Cards of that type.");
                                Console.ReadKey();
                            }
                            else
                            {
                                //Print list returned above 
                                Console.Clear();
                                int loopCount = 1;
                                foreach (Energy e in viewEnergy)
                                {

                                    {
                                        Console.WriteLine($"{loopCount}-\n{e}");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    loopCount++;
                                }
                            }

                                break;
                        case 2:
                                List<Item> viewItem= CardController.ViewItem(signedInUser);
                               // var view = viewItem.Where(x=> x.owner.Equals(signedInUser));
                                    //Print list returned above
                                    if (viewItem.Count() < 1)
                            {
                                Console.WriteLine("No Cards of that type.");
                                Console.ReadKey();
                            }
                            else
                            {
                                //Print list returned above 
                                Console.Clear();
                                int loopCount = 1;
                                foreach (Item i in viewItem)
                                {

                                    {
                                        Console.WriteLine($"{loopCount}-\n{i}");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    loopCount++;
                                }  
                            } 
                                    break;
                                case 3:
                                    CardController.ViewMonster(signedInUser);
                                    //Print list returned above
                                    break;
                                case 4:
                                    CardController.ViewEnergy(signedInUser);
                                    CardController.ViewItem(signedInUser);
                                    CardController.ViewMonster(signedInUser);

                                    //Print lists returned above
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
        }
    }



}