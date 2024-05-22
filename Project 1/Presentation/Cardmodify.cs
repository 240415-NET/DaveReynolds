using Project1.Controllers;
using Project1.Models;

namespace Project1.Presentation;


public class CardModify
{

    public static void RemoveCard(User signedInUser)
    {
        int userChoice = 0;
        bool validInput = true;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine($"Which type of {signedInUser.name}'s cards would you like to remove?");
            Console.WriteLine("1. Energy card");
            Console.WriteLine("2. Item card");
            Console.WriteLine("3. Monster card");
            Console.WriteLine("4. Go Back");

            int cardIdToRemove = 0;
            do
            {
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                    validInput = true;
                    switch (userChoice)
                    {
                        case 1:

                            CardView.ViewEnergyList(signedInUser);
                            Console.WriteLine("Please Enter Card # you wish to remove");
                            cardIdToRemove = Convert.ToInt32(Console.ReadLine());
                            Energy energyRemoved = CardController.RemoveEnergy(cardIdToRemove, signedInUser);
                            if (energyRemoved.cardId == cardIdToRemove)
                            {
                                Console.WriteLine("BELOW CARD REMOVED");
                                Console.WriteLine(energyRemoved);
                            }

                            break;
                        case 2:
                            CardView.ViewItemList(signedInUser);
                            Console.WriteLine("Please Enter Card # you wish to remove");
                            cardIdToRemove = Convert.ToInt32(Console.ReadLine());
                            Item itemRemoved = CardController.RemoveItem(cardIdToRemove, signedInUser);
                            if (itemRemoved.cardId == cardIdToRemove)
                            {
                                Console.WriteLine("BELOW CARD REMOVED");
                                Console.WriteLine(itemRemoved);
                            }
                            break;
                        case 3:
                            CardView.ViewMosterList(signedInUser);
                            Console.WriteLine("Please Enter Card # you wish to remove");
                            cardIdToRemove = Convert.ToInt32(Console.ReadLine());
                            Monster monsterRemoved = CardController.RemoveMonster(cardIdToRemove, signedInUser);
                            if (monsterRemoved.cardId == cardIdToRemove)
                            {
                                Console.WriteLine("BELOW CARD REMOVED");
                                Console.WriteLine(monsterRemoved);
                            }
                            break;


                            //Print list returned above
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
                    Console.WriteLine($"Which type of {signedInUser.name}'s cards would you like to remove?");
                    Console.WriteLine("1. Energy card");
                    Console.WriteLine("2. Item card");
                    Console.WriteLine("3. Monster card");
                    Console.WriteLine("4. Go Back");
                }
            } while (!validInput);
        }



    }


    public static void ModifyCard(User namedUser)
    {
        //pull list of cards

        //find card


        //change card
    }
}