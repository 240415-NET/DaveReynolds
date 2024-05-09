namespace week4;

public class Elephant:Animal, INoise
{
    public string subspecies {get; set;}
    public int trunkLength{get; set;}

    public void MakeNoise()

    {
        Console.WriteLine("trumpet");
    }
}