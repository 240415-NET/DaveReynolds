namespace trackmystuff.Models;

public interface IUserStorageRepo
{
    //Here we will add all storage methods
    public void StoreUser(User user);

    public User FindUser(string userNameToFind);

}