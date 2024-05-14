namespace Project1.Models;

public class Energy : Card
{
    public string elementalType{get; set;}
    

    public Energy(){}

    public Energy(string owner, string cardType, string artType, float value, string _elementalType):base(owner, cardType, artType, value)
    {
        elementalType = _elementalType;
        
    }

}
