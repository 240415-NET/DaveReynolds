namespace Project1.Models;

public class User
{
    public int userId{get; set;}
    public string name{get; set;}

    public User(){}

    public User(string _name)
    {
        userId = new Random().Next(1000, 9999);
        name = _name;
    }


}