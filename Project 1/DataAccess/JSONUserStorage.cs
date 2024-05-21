using System.Text.Json;
using Project1.Models;

namespace Project1.Data;

public class JSONUserStorage : IUserStorageRepo
{

    public static readonly string filePath = "UsersFile.Json";
    public void StoreUser(User user)
    {
        //file paths begin in root directory of application


        if (File.Exists(filePath))//if json file exsists
        {
            //converts Json file to string of text
            string exsistingUserJson = File.ReadAllText(filePath);
            //converts string to a new list of User objects
            List<User> exsistingUserList = JsonSerializer.Deserialize<List<User>>(exsistingUserJson);
            //add passed in user object to list
            exsistingUserList.Add(user);
            //converts list of User Objects to string of text
            string exsistingUserString = JsonSerializer.Serialize(exsistingUserList);
            //write that text to a Json file with the file name declared above
            File.WriteAllText(filePath, exsistingUserString);

        }
        else if (!File.Exists(filePath))//first time the program is run
        {
            //create List of User objects
            List<User> initialUserList = new List<User>();
            //add passed in user object to list
            initialUserList.Add(user);
            //convert list to text
            string jsonUsersString = JsonSerializer.Serialize(initialUserList);
            //write that text to a Json file with the file name declared above
            File.WriteAllText(filePath, jsonUsersString);
        }

    }
    public User FindUser(String userNameToFind)
    {
        User foundUser = new User();

        try
        {
            //using same method to pull Json info as above
            string exsistingUserJson = File.ReadAllText(filePath);
            List<User> exsistingUserList = JsonSerializer.Deserialize<List<User>>(exsistingUserJson);

            //searching user list for usernamed that is passed in
            foundUser = exsistingUserList.FirstOrDefault(user => user.name == userNameToFind);

        }
        catch (Exception e)
        {

        }
        return foundUser;
    }

    List<User> IUserStorageRepo.ReturnUsersList()
    {
        throw new NotImplementedException();
    }
}