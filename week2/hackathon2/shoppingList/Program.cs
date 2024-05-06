namespace shoppingList;

using System.Collections;
using shoppingList.Classes;
class Program
{
    static void Main(string[] args)
    {
        List<ItemsToBuy> ItemsOnList = new List<ItemsToBuy>();
        Console.WriteLine("Hello, Shopper! We're ready to begin your shopping list.");
        
        
        int itemNum = 1;
        bool quit = false;
        while(quit != true)
        {
        Console.WriteLine("Please enter an item for your shopping list, q to quit, or p to Print");
        string userInput = Console.ReadLine().Trim();
        switch(userInput.ToLower()) 
        {
        case "q" or "quit":
        
            quit = true;
        break;
        case "p" or "print":
        
            Console.Clear();
            foreach(var item in ItemsOnList)
            {
                int i =0;
                Console.WriteLine(item);
                
            }
            Console.ReadLine();
            bool addBreak = false;
            while (addBreak == false)
            {
            Console.WriteLine("Have you added any items to your cart? y or n");
            string addItem = Console.ReadLine();
            //this can be a method
            switch (addItem.ToLower())
            {
                case "y":
                //class to update items
                addBreak = true;
                break;
              
                case "n":
                addBreak = true;
                break;
                
                default:                
                break;
            }
            
            }
            break;
        case "":
        Console.WriteLine("Please enter item");
        break;
        default:
         ItemsToBuy newItem = new ItemsToBuy(userInput, false);
            ItemsOnList.Add(newItem);
            
        break;
        }
        
        }
}
}