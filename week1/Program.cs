namespace week1;

class Program
{
    static void Main(string[] args)
    {
        int i = 1;
		while (i<101)
		{
			if(i%3==0 && i%5 ==0)
			{
				Console.WriteLine("fizzbuzz");
			}
			else if(i%5==0)
			{
					Console.WriteLine("buzz");
			}
			else if(i%3 == 0)
			{
				Console.WriteLine("fizz");
			}
			else Console.WriteLine(i);
			i+= 1;
		}
    }
}
