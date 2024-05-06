using System.Text;

namespace Project1.Models;

public class Card
{
    public string owner{get; set;}
    public string cardType {get; set;}
    public string artType{get; set;} = "Normal";
    public float value{get; set;} = 0;

    public Card(){}

    public Card(string _owner, string _cardType, string _artType, float _value)
    {
        owner = _owner;
        cardType = _cardType;
        artType = _artType;
        value = _value;
    }
}