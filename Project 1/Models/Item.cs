namespace Project1.Models;

public class Item : Card
{
    public string name { get; set; }
    public char rarity { get; set; } = 'C';

    public Item() { }

    public Item(string owner, string cardType, string artType, float value, string _name, char _rarity) : base(owner, cardType, artType, value)
    {
        name = _name;
        rarity = _rarity;

    }
    public override string ToString()
    {
        //return $"Owner: {owner}\nCard#;{cardId}\nCard Name: {name}\nType: {cardType}\nArt Type: {artType}\nValue: {value}\nRarity: {rarity}";
        return String.Format("Owner: {0,-10}|Card #: {1,7}|Type: {2,-13}|Card Name:{3, -10} |Art Type: {4,-10}|Value: {5, -5:C2}|Rarity: {6,-6}", owner, cardId, cardType, name, artType, value, rarity);
    }

}