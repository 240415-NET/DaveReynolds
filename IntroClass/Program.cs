namespace IntroClass;

class Program
{
    static void Main(string[] args)
    {
        
        
        Console.WriteLine("How many dogs do you have?");
        int numDogs = Convert.ToInt16(Console.ReadLine().Trim());
      
      
    
      AddDogs(numDogs);
     
        
        
      
        // call an instance method called via dot notation instance.method()
        //pancake.Bark();
        // call static method class.method()
        Dog.DefineDog();

    }

    public static void AddDogs(int numDogs)
    {
        List<Dog> DogList = new();
         int i=0;
         while(i<numDogs)
         {
            Console.WriteLine($"Enter Dog {i+1}'s Name, breed, age, gender, weight");
            DogList.Add(new Dog(Console.ReadLine(), Console.ReadLine(),Convert.ToInt16(Console.ReadLine()), Console.ReadLine(), Convert.ToDouble(Console.ReadLine())));
            Console.WriteLine(DogList[i]);
            i++;
   

        } 
                    
                    for(int a=0; a < numDogs; a++)
        {
            Console.WriteLine(DogList{a}.GetType());
            Console.WriteLine($"{DogList.name[a]} is a {dog.breed[a]}");

        }

    }

}


