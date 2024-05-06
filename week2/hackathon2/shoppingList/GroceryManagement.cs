using System.Data;

namespace shoppingList.GroceryManagement
{
    public class GroceryManagementMethods
    {
        public static void MainMenu()
        {
            List<ItemsToBuy> ItemsOnList = new List<ItemsToBuy>();
        Console.WriteLine("Hello, Shopper! We're ready to begin your shopping list.");
        bool quit = false;
        while(quit != true)
        {
            Console.WriteLine("1. Add item\n2. Print List\n3. Shop\n4. Quit");
            string userInput = Console.ReadLine().Trim();
            switch(userInput.ToLower()) 
            {
                case "4":
                    quit = true;
                break;
                case "2"://Print
                    GroceryManagementMethods.PrintList(ItemsOnList);
                    bool addBreak = false;
                    break;
                    case "3": //Mark as purchased
                    GroceryManagementMethods.ShopLoop(ItemsOnList);
                    break;
           
                case "1":
                    GroceryManagementMethods.AddList(ItemsOnList);
                break;
                default:
                    Console.WriteLine("select from valid entry");
                break;
            }
            
        }
    
   

        }
        public static void UpdateList()
        {

        }

        public static void MarkPurchased(List<ItemsToBuy> ItemsOnList)
        {
            Console.WriteLine("Which Item to add to cart?");
            string AddCart = Console.ReadLine().Trim();
            foreach(var item in ItemsOnList)
                    {
                    if(item.Description == AddCart)
                        {
                        item.SetPurchased(true);
                        Console.Clear();
                        break;
                        }
                    }
        }

        public static void AddList(List<ItemsToBuy> ItemsOnList)
        {
            Console.WriteLine("Please enter item");
                string Additem = Console.ReadLine().Trim();
                ItemsToBuy newItem = new ItemsToBuy(Additem, false);
                    ItemsOnList.Add(newItem);
        }

        public static void PrintList(List<ItemsToBuy> ItemsOnList)
        {
            Console.Clear();
            foreach(var item in ItemsOnList)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadLine();
        }
        public static void ShopLoop(List<ItemsToBuy> ItemsOnList)
        {
          bool StopShop = false;
                        do{
                            GroceryManagementMethods.PrintList(ItemsOnList);
                            GroceryManagementMethods.MarkPurchased(ItemsOnList);
                            GroceryManagementMethods.PrintList(ItemsOnList);
                            Console.WriteLine("Add another item? y/n");
                            string AddAnotherCart = Console.ReadLine();
                            if (AddAnotherCart == "n")
                            {StopShop = true;}

                        }while (StopShop == false);  
        }
    
    }
    
}