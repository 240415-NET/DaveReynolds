using Microsoft.AspNetCore.Mvc;
using TrackMyStuff.API.Models;
using TrackMyStuff.API.DTOs;
using TrackMyStuff.API.Services;

namespace TrackMyStuff.API.Controllers;
//we are going to break our business logic into a service layer outside our controllers to keep them relatively small
//Controllers in an ASP.NET application only handle reciving/returning HTTP requests

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    //I know that I am going to need at minimum a place to hold my User service object that will be given to me by the builder
    //when the app is dotnet run
    //we are NOT going to instantiate this object within the contoller with myObject = new Object90 style
    //we ar going to allow the builder to handle creating and then passing that UserService object through the constructor
    private readonly IUserService _userService;
    //here we will take in our dependencies (auto passed in by builder)
    public UserController(IUserService userServiceFromBuilder)
    {
        _userService = userServiceFromBuilder;
    }
    //create a USER in our DB
    //here we are going to create our first controller method
    // it needs an HTTP verb tag, a method signature that includes the "async" keyword.
    // makes the method asyncronus, meaning that we won't have to wait for a single user to finish executing
    [HttpPost]
    public async Task<ActionResult<User>> PostNewUser(string userName)
    {
        //inside our controller we're going to call a method from our Service layer
        //we are going to wrap this in a try catch so that if anything goes wrong our entire API won't go down
        try
        {
            User newUser = new User(userName);
            
            //Inside of our try we call the CreateNewUserAsync in our serive
            //the service layer will handle validitating that this object meets our criteria
            await _userService.CreateNewUserAsync(newUser);
            // if it does we return 200-success Method and echo back the object
            return Ok(newUser);

            //if for some reason the CreateNewUserAsync fails we will hit the catch
        } 
        catch(Exception e)
        {
            //if something goes wrong, we are going to return a 400 bad request response with the ex message it triggered
            return BadRequest(e.Message);
        }
    }

    //write a get method to return a single user from DB based on User name from frontend
    [HttpGet("/Users/{userNameToFindFromFrontEnd}")]
    public async Task<ActionResult<User>> GetUserByUserName(string userNameToFindFromFrontEnd)
    {

        //again starting with a try catch so that API does not exit on error
        //and that error can be passed back
        try 
        {
            return await _userService.GetUserByUserNameAsync(userNameToFindFromFrontEnd);
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("User/{usernameToDeleteFromFrontEnd}")]
    public async Task<ActionResult> DeleteUserbyUserNameAsync(string usernameToDeleteFromFrontEnd)
    {
       try
       {
            //call delete method in our service layer
             _userService.DeleteUserByUsernameAsync(usernameToDeleteFromFrontEnd);
            //if all goes well we will return 200 ok to the front end
        return Ok($"{usernameToDeleteFromFrontEnd} Deleted");
       }
       catch (Exception e)
       {
        return NotFound(e.Message);
       }
       
    
    }

}