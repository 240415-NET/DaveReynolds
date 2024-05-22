using Project1.Data;
using Project1.Models;

namespace Project1.Controllers;


public class CardController
{
  public static ICardStorageRepo _cardData = new JsonCardStorage();


  public static void CreateCard(string _owner, string _cardType, string _artType, float _value, string _elementalType, string _cardName, char _rarity)
  {
    if (_cardType == "Energy")
    {
      Energy newCard = new Energy(_owner, _cardType, _artType, _value, _elementalType);
      _cardData.StoreEnergy(newCard);
    }
    else if (_cardType == "Trainer/Item")
    {

      Item newCard = new Item(_owner, _cardType, _artType, _value, _cardName, _rarity);
      _cardData.StoreItem(newCard);
    }
    else if (_cardType == "Monster")
    {
      Monster newCard = new Monster(_owner, _cardType, _artType, _value, _cardName, _rarity, _elementalType);
      _cardData.StoreMonster(newCard);
      Console.WriteLine(newCard.elementalType);
      

    }
  }

  public static List<Energy> ViewEnergy(User namedUser)
  {
    return _cardData.GetEnergyList(namedUser);

  }
  public static List<Item> ViewItem(User namedUser)
  {
    return _cardData.GetItemList(namedUser);

  }
  public static List<Monster> ViewMonster(User namedUser)
  {
    return _cardData.GetMonsterList(namedUser);

  }

  public static
}
