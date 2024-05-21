namespace Project1.Models;

public class Monster : Item
{
    string elementalType{get; set;}

    public Monster(){}

    public Monster(string owner, string cardType, string artType, float value, string name, char rarity, string _elementalType): base (owner, cardType, artType, value, name, rarity)
    {
        elementalType = _elementalType;
    }
    public override string ToString()
    {
        return $"Owner: {owner}\nCard#;{cardId}\nCard Name: {name}\nType: {cardType}\nArt Type: {artType}\nValue: {value}Elemental: {elementalType}\nRarity: {rarity}";
    }
}