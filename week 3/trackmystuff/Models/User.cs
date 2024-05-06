using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace trackmystuff.Models;
public class User
{
    //fields default internal
    public Guid userId{get; set;}
    public string userName {get; set;}

    //public static string GetName(User User1)
    //{
       // return User1.userName;
    //}

    //constructors
    // default constructor
    public User(){}
    public User(string _userName)
    {
        userId = Guid.NewGuid(); 
        userName =  _userName;
    }
    
}
