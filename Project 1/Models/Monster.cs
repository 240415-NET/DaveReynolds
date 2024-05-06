namespace Project1.Models;

public class Monster : Object
{
    string elementalType{get; set;}

    public Monster(){}

    public Monster(string owner, string cardType, string artType, float value, string name, char rarity, string _elementalType): base (owner, cardType, artType, value, name, rarity)
    {
        elementalType = _elementalType;
    }
}