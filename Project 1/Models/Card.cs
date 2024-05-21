using System.Dynamic;
using System.Text;

namespace Project1.Models;

public class Card
{
    public string owner{get; set;}
    public int cardId{get; set;}
    public string cardType {get; set;}
    public string artType{get; set;} = "Normal";
    public float value{get; set;} = 0;
    //general constrcutor
    public Card(){}
    //specific constructor
    public Card(string _owner, string _cardType, string _artType, float _value)
    {
        owner = _owner;
        cardId = new Random().Next(10000, 99999);
        cardType = _cardType;
        artType = _artType;
        value = _value;
    }
}