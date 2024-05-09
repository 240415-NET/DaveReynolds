using Project1.Models;

namespace Project1.Controllers;


public class CardController
{

  public static void CreateCard(string _owner, string _cardType, string _artType, float _value, string _elementalType, string _cardName, char _rarity)
  {
    if (_cardType == "Energy"){
      Energy newCard = new Energy(_owner, _cardType, _artType, _value, _elementalType);
    }
    else if (_cardType == "Trainer/Item"){
      Models.Object newCard = new Models.Object(_owner, _cardType, _artType, _value, _cardName, _rarity);
    }
    else if (_cardType == "Monster"){
      Monster newCard = new Monster(_owner, _cardType, _artType, _value, _cardName, _rarity, _elementalType);
    }
    //Pass New Card to data Handler
    //CardStorage.StoreCard(newCard);
  }
}
