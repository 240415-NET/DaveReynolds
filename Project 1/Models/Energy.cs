using System.Collections;

namespace Project1.Models;

public class Energy : Card
{
    public string elementalType { get; set; }


    public Energy() { }

    public Energy(string owner, string cardType, string artType, float value, string _elementalType) : base(owner, cardType, artType, value)
    {
        elementalType = _elementalType;

    }

    public override string ToString()
    {
        //r2eturn $"Owner: {owner}\nCard#;{cardId}\n Type: {cardType}\nArt Type: {artType}\nValue: {value}\nElement: {elementalType}";
        return String.Format("Owner: {0,-10}|Card #: {1,7}|Type: {2,-13} |Art Type: {3,-5}|Element: {4, -5}|Value: {5, -5:C2}", owner, cardId, cardType, artType, elementalType, value);
    }

}

