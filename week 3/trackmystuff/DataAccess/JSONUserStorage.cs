using System.Text.Json;
using trackmystuff.Models;
using trackmystuff.Data;

namespace trackmystuff.Data;

public class JSONUserStorage : IUserStorageRepo
{
    public static readonly string filePath = "UsersFile.Json";
    public void StoreUser(User user)
    {
            // file paths begin at root directory of application
        //string filePath = "UsersFile.Json";
       
        
        // we want to create a JSON file from out method if one doesn't exist
        if (File.Exists(filePath))
        {
       // here we will read the file for a collection of users, add user
        //rewrite the files
            
        //deserialize the existing json test and store in list
        //when we deserialize we have to be explicit with our type
        //deserialize method needs to knwow what kind of object it will create
          //don't forget to  
           string exsistingUserJson = File.ReadAllText(filePath);
           
            List<User> exstingUsersList = JsonSerializer.Deserialize<List<User>>(exsistingUserJson);
        
        //Once deserialized we can add new object to list with .add() method
            exstingUsersList.Add(user);

            string jsonexsistingUsersString = JsonSerializer.Serialize(exstingUsersList);
        // now will store our jsonusersString  to our file
            File.WriteAllText(filePath,jsonexsistingUsersString);

        }
        else if(!File.Exists(filePath)) //first time program runs the files probably doesn't exsist
        {
            //creating blank list
            List<User> initialUsersList = new List<User>();
        //adding user to list, prior to serializing (converting to text) it
            initialUsersList.Add(user);
        //serialize our list of users to a json text string
            string jsonUsersString = JsonSerializer.Serialize(initialUsersList);
        // now will store our jsonusersString  to our file
            File.WriteAllText(filePath,jsonUsersString);
            
        }
        //If it does we want to append new object to file
        //if it doesn't create file and store object
    }

    public User FindUser(string userNameToFind) 
    {
            //user object to store user if found, otherwise null
            User foundUser = new User();

        //read sting back from .json
        try
        {
        //serialize string back into userObjects
            string exsistingUserJson = File.ReadAllText(filePath);
           
            List<User> exstingUsersList = JsonSerializer.Deserialize<List<User>>(exsistingUserJson);

            // using LINQ method FirstOrDefault
            // => is lambda operator. it's an arrow
            foundUser = exstingUsersList.FirstOrDefault(user =>user.userName == userNameToFind);
            
            //first or default lambda method in long hand
            // foreach (User user in exstingUsersList)
            // {
            //     if (user.userName == userNameToFind)
            //     {
            //         return user;
            //     }
            // }
           Console.WriteLine(foundUser.userId);
           Console.WriteLine(foundUser.userName);
                
            
        }
        catch(Exception ex)
        {
            //Console.WriteLine(ex);
        }
       return foundUser;

        //check for user object with UserName passed in

        //if it exsists return user else somethin

    }

}