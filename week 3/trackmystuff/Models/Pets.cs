namespace trackmystuff.Models;

public class Pet : Item
{
    // ? allows to be defined value or null
    public string name{get; set;}
   public string? species{get; set;}
    public int? age{get; set;}
    public Pet(){}

    public Pet ( int ItemId, int ownerId, string category, float originalCost, DateTime purchaseDate, string description, string _name, string _species, int _age): base (ItemId, ownerId, category, originalCost, purchaseDate, description) 
    {
        name = _name;
        species = _species;
        age = _age;

    }
}

