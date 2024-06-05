//add code from console app
using System.ComponentModel.DataAnnotations;

namespace TrackMyStuff.API.Models;

public class User
{
    //Fields

    //This is an example of leveraging the get;set; shorthand to protect our fields/properties
    //We can shift the burden of the access modifier to the getter or setter, and avoid having
    //to write more code to create a traditional field and property

    //We are using a prebuilt data type from the default System library to generate a truly unique
    //userId
    [Key]
    public Guid userId { get; set; }
    public string userName { get; set; }
    //users have many Items - each one belongs to one user
    // we store these in our models as lists of type 
    //have to initialize a new list otherwise it will not be associated in DB
    public List<Item> items { get; set; } = new();
    public List<Pet> Pets { get; set; } = new();
    public List<Document> Documents { get; set; } = new();


    //Constructors

    //Default/No argument constructor
    public User() { }

    //This constructor takes two arguments
    public User(string _userName)
    {
        userId = Guid.NewGuid(); //This creates a random Guid for us, without us having to worry about it
        userName = _userName;
    }


}
