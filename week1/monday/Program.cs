namespace monday;

class Program
{
    static void Main(string[] args)
    {
        

        
        int[] studentGrades = {97, 93, 100,93};
        
        /*for (int i = 0; i < 4; i++)
        {
        Console.WriteLine(i);
        Console.WriteLine(studentGrades[i]);
        }
        */
        char[] helloChar = {'H', 'E', 'L', 'L', 'O',};
        string helloString = new string(helloChar);
        Console.WriteLine(helloString);
        Console.WriteLine(helloChar);
        //to chararray
        string worldString = "world!";
        char[] worldChar = worldString.ToCharArray();
        Console.WriteLine(worldString);
        Console.WriteLine(worldChar);
        //string methods
        string newWord = Console.ReadLine();
        string newWordUpper = newWord.ToUpper();
        Console.WriteLine(newWord);
        Console.WriteLine(newWordUpper);
        //ToUpper is a method that does not update varible newWord but returns a new string. a seperate declaration statement is needed to change the value
        Console.WriteLine(newWord.ToLower());

        foreach(char c in newWord)
        {

            Console.WriteLine(c);
        }

        for(int i = 2; i< newWord.Count(); i++)
        { 
            Console.WriteLine(newWord[i]);
        }
        //method chaining
        string name = Console.ReadLine();

        if (name.ToLower().Contains("mike"))
        {
            Console.WriteLine("hello Mike!");
        }
        else
        {
            Console.WriteLine($"Hello {name}");
        }
        Console.WriteLine(name.Replace('a', 'u'));

}
}