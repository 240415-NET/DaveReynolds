namespace IntroClass;

public class Dog(string name, string breed, int age, string gender, double weight)
{
    //A class has memeber
    // these members are fields (variables) and methods
    //good idea to seperate fields and methods
    //fields
    // we need access modifiers otherwise default is internal
    

    public string name {get; set;}
        /*{
        get{return name;} 
        set{ name = value;}//value is passed from call
        }*/

    public string breed{get; set;}
    public int age{get; set;}
    public string gender{get; set;}
    public double weight{get; set;}

    //methods
    
    //this is a instance method
    public void Bark()
    {
        Console.WriteLine("bark bark");
    }
    //example of static method
    public static void DefineDog()
    {
        Console.WriteLine("Dog definition");
    }
}