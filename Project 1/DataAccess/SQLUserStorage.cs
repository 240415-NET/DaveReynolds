using Project1.Models;
using System.Data.SqlClient;

namespace Project1.Data;
//in order to change from JSON to SQL upddate in Controller 

public class SqlUserStorage : IUserStorageRepo
{

    //using a verbatim string literal @ to ignore all issues related to the slashes for windows file paths
    public static string connectionString = File.ReadAllText(@"C:\Users\U0SA29\Documents\Revature\bootcamp\connstring.txt");

    public User FindUser(string userNameToFind)
    {
        //just like in JSON we will create an empty user to hold potential USER we find in our DB
        User foundUser = new User();
        //just like in INSER we will create a n SQLCOnenction
        using SqlConnection connection = new SqlConnection(connectionString);


        try
        {


            connection.Open();

            string cmdText = @" SELECT userID, userName 
                                FROM dbo.Users
                                WHERE userName = @userToFind;";

            // create our sql command object

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            //we then fill parameter
            cmd.Parameters.AddWithValue("@userToFind", userNameToFind);

            // to exectue a query we need to use sqlDatatReader
            //this object reads wheever is returened from our query , row by row
            //as the reader passes over the columns we nee to take steps to sotre our work
            //once the reader movers on from a row  we need to execute the comd again to re-read
            //there is no going back

            using SqlDataReader reader = cmd.ExecuteReader();

            // we are going to use a while loop to read through our data coming from sql data reader
            // and execute code until it is done reading

            while (reader.Read())
            {
                //while we are on a row we have to save stuff if we find it
                //when using reader.getType()methods, 

                foundUser.userId = reader.GetInt32(0);
                foundUser.name = reader.GetString(1);

            }//once done and no more records are coming back we exit loop
            if (String.IsNullOrEmpty(foundUser.name))
            {
                return null;
            }


            // if we get to this point and found a user, we teturn the filled out User object
            return foundUser;
        }
        catch (Exception e)
        {
            Console.WriteLine("here?");
            Console.WriteLine(e.Message);
        }
        finally
        {
            //we will leverage finally block to close connection incase nothing is found or we catch some exception
            connection.Close();
        }
        return null;
    }

    public void StoreUser(User user)
    {
        //create sql connection object to be able to connect to our DB.
        //we want this object ot be "disposable" - Destroyed or dereferenced once method is done execution
        //this is done with a "using' statement

        using SqlConnection connection = new SqlConnection(connectionString);

        //after we create our connection object we call an instance method called Open() to open connection
        connection.Open();

        //after this we start to create our command. we can do this with a templated string
        // doing this we sanitize inputs and protect against sql injection 
        string cmdText = @"INSERT INTO dbo.Users (userId, userName)
                            VALUES(@userId, @userName);";

        // we use the conenctiion we created and opned, as well as the command text template we created above
        //to create a new sqlCommand object that we will eventually send to do stuff on out DB
        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        //now that we have our SqlCommand object (cmd) we cna call a method AddWithValue()
        //to fill out the templated INSERT command string
        //we call this a little diffeerently than other instance methods, because we are reaching deeper into 
        //the cmd object

        cmd.Parameters.AddWithValue("@userID", user.userId);
        cmd.Parameters.AddWithValue("@userName", user.name);

        //we then execute our insert statement that we created and fleshed out above by running
        //the instance mehtod execureNoNQuery() off our cmd object
        cmd.ExecuteNonQuery();

        //close connection
        connection.Close();

    }
    public List<User> ReturnUsersList()
    {
        //just like in JSON we will create an empty user to hold potential USER we find in our DB
        List<User> foundUsers = new List<User>();
        //just like in INSER we will create a n SQLCOnenction
        using SqlConnection connection = new SqlConnection(connectionString);


        


        connection.Open();
        //sql query for user table

        string cmdText = @" SELECT userID, userName 
                                FROM dbo.Users";

        // create our sql command object

        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        using SqlDataReader reader = cmd.ExecuteReader();
        

        // we are going to use a while loop to read through our data coming from sql data reader
        // and execute code until it is done reading

        while (reader.Read())
        {
            //while we are on a row we have to save stuff if we find it
            //when using reader.getType()methods, 


            foundUsers.Add(new User(reader.GetInt32(0), reader.GetString(1)));

        }//once done and no more records are coming back we exit loop
          
         connection.Close();
        // if we get to this point and found a user, we teturn the filled out User object
        return foundUsers;

        //we will leverage finally block to close connection incase nothing is found or we catch some exception
        



    }
}