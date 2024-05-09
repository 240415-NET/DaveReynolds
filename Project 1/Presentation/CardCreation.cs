namespace Project1.Presentation;

using Project1.Controllers;
using Project1.Models;
public class CardInput
{
    public static void CreateCardMenu(User signedInUser)
    {
        int userChoice = 0;
        bool validInput = true;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("What kind of card is it?");
            Console.WriteLine("1. Energy");
            Console.WriteLine("2. Trainer/Item");
            Console.WriteLine("3. Monster");
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
                            CreateCardInput(signedInUser, 1);
                            break;
                        case 2:
                            CreateCardInput(signedInUser, 2);
                            break;
                        case 3:
                            CreateCardInput(signedInUser, 3);
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

    public static void CreateCardInput(User signedInUser, int type)
    {
        float value = 0;
        bool validInput = true;
        string owner = signedInUser.name;
        string elementalType = "";
        string cardName = "";
        char cardRarity = 'C';
        Console.WriteLine("Enter art type");
        Console.WriteLine("Normal, Holo, Reverse Holo, Full Art, etc.:");
        string artType = Console.ReadLine().Trim();
        Console.WriteLine("Enter Value:");
        do{
            try{
                value = Convert.ToInt32(Console.ReadLine());
                validInput = true;
            }

            catch (Exception ex){
                validInput = false;
                //Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Please enter dollar amount");
            }
        } while (!validInput);

        if (type == 1 || type == 3)
        {
            Console.WriteLine("Enter Elemental Type:");
            elementalType = Console.ReadLine().Trim();
        }
        if (type == 2 || type == 3)
        {
            Console.WriteLine("Enter Card Name:");
            cardName = Console.ReadLine().Trim();
            do
            {
                try
                {
                    Console.WriteLine("Enter Card Rarity:");
                    Console.WriteLine("C - Common, U - Uncommon, R - Rare ");
                    cardRarity = Convert.ToChar(Console.ReadLine().ToUpper());
                    validInput = true;
                }
                catch (Exception)
                {
                    validInput = false;
                    Console.WriteLine("Enter C, U, or R");
                }
            } while (!validInput);
        }
        if (type == 1)
        {
            CardController.CreateCard(owner, "Energy", artType, value, elementalType, "", 'C');
        }
        if (type == 2)
        {
            CardController.CreateCard(owner, "Trainer/Item", artType, value, "", cardName, cardRarity);
        }
        if (type == 3)
        {
            CardController.CreateCard(owner, "Monster", artType, value, elementalType, cardName, cardRarity);
        }
    }


}