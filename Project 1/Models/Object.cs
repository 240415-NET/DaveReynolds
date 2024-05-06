namespace Project1.Models;

public class Object : Card
{
    public string name{get; set;}
    public char rarity{get; set;} = 'C';
    
    public Object(){}

    public Object(string owner, string cardType, string artType, float value, string _name, char _rarity): base (owner, cardType, artType, value)
    {
        name = _name;
        rarity = _rarity;

    }

}