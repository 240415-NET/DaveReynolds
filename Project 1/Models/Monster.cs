namespace Project1.Models;

public class Monster : Item
{
    public string elementalType { get; set; }

    public Monster() { }

    public Monster(string owner, string cardType, string artType, float value, string name, char rarity, string _elementalType) : base(owner, cardType, artType, value, name, rarity)
    {
        elementalType = _elementalType;
    }
    public override string ToString()
    {
        //return $"Owner: {owner}\nCard#;{cardId}\nCard Name: {name}\nType: {cardType}\nArt Type: {artType}\nValue: {value}\nElemental: {elementalType}\nRarity: {rarity}";
        return String.Format("Owner: {0,-10}|Card #: {1,7}|Type: {2,-15}|Card Name:{3, -10} |Art Type: {4,-10}|Element: {5, -10}|Value: {6, -5:C2}", owner, cardId, cardType, name, artType, elementalType, value);
    }
}