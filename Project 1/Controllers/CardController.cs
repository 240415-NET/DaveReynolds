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

  public static Energy RemoveEnergy(int _cardID, User namedUser)
  {

    List<Energy> energyList = _cardData.GetEnergyList(namedUser);
    var foundCard = from card in energyList
                    where card.cardId == _cardID
                    select card;

    List<Energy> deleteCard = foundCard.ToList();
    if (deleteCard.Count > 0)
    {
      energyList.Remove(deleteCard[0]);
      _cardData.UpdateEnergy(energyList);
      return deleteCard[0];
    }
    else
    {
      Console.WriteLine($"Card ID {_cardID} not found");
      return deleteCard[0];
    }
  }
public static Item RemoveItem(int _cardID, User namedUser)
  {

    List<Item> itemList = _cardData.GetItemList(namedUser);
    var foundCard = from card in itemList
                    where card.cardId == _cardID
                    select card;

    List<Item> deleteCard = foundCard.ToList();
    if (deleteCard.Count > 0)
    {
      itemList.Remove(deleteCard[0]);
      _cardData.UpdateItem(itemList);
      return deleteCard[0];
    }
    else
    {
      Console.WriteLine($"Card ID {_cardID} not found");
      return deleteCard[0];
    }



  }

  public static Monster RemoveMonster(int _cardID, User namedUser)
  {

    List<Monster> monsterList = _cardData.GetMonsterList(namedUser);
    var foundCard = from card in monsterList
                    where card.cardId == _cardID
                    select card;

    List<Monster> deleteCard = foundCard.ToList();
    if (deleteCard.Count > 0)
    {
      monsterList.Remove(deleteCard[0]);
      _cardData.UpdateMonster(monsterList);
      return deleteCard[0];
    }
    else
    {
      Console.WriteLine($"Card ID {_cardID} not found");
      return deleteCard[0];
    }



  }
  public static Energy ModifyEnergy(int _cardID, User namedUser, string tradeName)
  {

    List<Energy> energyList = _cardData.GetEnergyList(namedUser);
    var foundCard = from card in energyList
                    where card.cardId == _cardID
                    select card;

    List<Energy> tradeCard = foundCard.ToList();
    if (tradeCard.Count > 0)
    {
      energyList.Remove(tradeCard[0]);
      tradeCard[0].owner = tradeName;
      energyList.Add(tradeCard[0]);
      _cardData.UpdateEnergy(energyList);
      return tradeCard[0];
    }
    else
    {
      Console.WriteLine($"Card ID {_cardID} not found");
      return tradeCard[0];
    }
  }
}

