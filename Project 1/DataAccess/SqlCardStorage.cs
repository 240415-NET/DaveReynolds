using Project1.Models;
using System.Data.SqlClient;

namespace Project1.Data;

public class SqlCardStorage : ICardStorageRepo
{
    public static string connectionString = File.ReadAllText(@"C:\Users\U0SA29\Documents\Revature\bootcamp\connstring.txt");

    public void UpdateEnergy(List<Energy> updatedList)
    {
        throw new NotImplementedException();
    }

    public void UpdateItem(List<Item> updatedList)
    {
        throw new NotImplementedException();
    }

    public void UpdateMonster(List<Monster> updatedList)
    {
        throw new NotImplementedException();
    }

    List<Energy> ICardStorageRepo.GetEnergyList(User namedUser)
    {
        throw new NotImplementedException();
    }

    List<Item> ICardStorageRepo.GetItemList(User namedUser)
    {
        throw new NotImplementedException();
    }

    List<Monster> ICardStorageRepo.GetMonsterList(User namedUser)
    {
        throw new NotImplementedException();
    }

    void ICardStorageRepo.StoreEnergy(Energy newEnergy)
    {
        throw new NotImplementedException();
    }

    void ICardStorageRepo.StoreItem(Item newItem)
    {
        throw new NotImplementedException();
    }

    void ICardStorageRepo.StoreMonster(Monster newMonster)
    {
        throw new NotImplementedException();
    }
}
