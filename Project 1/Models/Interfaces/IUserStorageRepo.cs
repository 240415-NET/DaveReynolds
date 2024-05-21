namespace Project1.Models;
using Project1.Data;

public interface IUserStorageRepo
{
    public void StoreUser(User user);

    public User FindUser(String userNameToFind);

    public List<User> ReturnUsersList();

}