using Project1.Models;

namespace Project1.Data;

public class SqlUserStorage
{

    //using a verbatim string literal @ to ignore all issues related to the slashes for windows file paths
    public static string connectionString = File.ReadAllText(@"C:\Users\U0SA29\Documents\Revature\bootcamp\connstring.txt");
}