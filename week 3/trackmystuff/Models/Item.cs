using System.Security.Cryptography;

namespace trackmystuff.Models;


public class Item
{
   public int ItemId{get; private set;}
   public int ownerId {get; private set;}
    public string category{get; set;}
    public float? originalCost{get; set;}
    public DateTime purchaseDate{get; set;}
   public string description{get; set;}
   public Item(){}
   public Item(int _ItemId, int _ownerId, string _category, float _originalCost, DateTime _purchaseDate, string _description)
   {
    ItemId = _ItemId;
    ownerId = _ownerId;
    category = _category;
    originalCost = _originalCost;
    purchaseDate = _purchaseDate;
    description = _description;


   }
   
}

