namespace shoppingList.Classes
{
    public class ItemsToBuy
    {
        //fields
        private string Description ="Item";
        private bool Purchased = false;

        //defualt constructor
        public ItemsToBuy()
        {

        }
        public ItemsToBuy(string Description, bool Purchased)
        {
            this.Description = Description;
            this.Purchased = Purchased;
        }
        //methods
        public string GetDescription()
        {
            return this.Description;
        }
        public void SetDescription(string Description)
        {        
            this.Description = Description;           
        }

        public bool GetPurchsed()
        {
            return this.Purchased;
        }
        public void SetPurchased(bool Purchased)
        {
            this.Purchased = Purchased;
        }
        //override ToString
        public override string ToString()
        {
            string CurrentStatus = "_";
            if(Purchased)
            {CurrentStatus = "X";}
            int i = 1;
            return $"{Description} --- {CurrentStatus}";
            
        }

    }
}