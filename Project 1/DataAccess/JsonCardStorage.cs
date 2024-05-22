using Project1.Data;
using Project1.Models;

public class JsonCardStorage : ICardStorageRepo
{
    public void StoreEnergy(Energy newEnergy)
    {
        List<Energy> existingEnergyList = DTOStorage.DeserializeEnergy();
        //Once we deserialize our exisitng JSON text from the file into a new List<item> object
        //We will then simply add it to the list, using the Add() method
        existingEnergyList.Add(newEnergy);
        DTOStorage.SerializeEnergy(existingEnergyList);

    }
    public void StoreMonster(Monster newMonster)
    {
        List<Monster> existingMonsterList = DTOStorage.DeserializeMonster();
        //Once we deserialize our exisitng JSON text from the file into a new List<item> object
        //We will then simply add it to the list, using the Add() method
        existingMonsterList.Add(newMonster);
        DTOStorage.SerializeMonster(existingMonsterList);

    }
    public void StoreItem(Item newItem)
    {

        List<Item> existingItemsList = DTOStorage.DeserializeItem();
        //Once we deserialize our exisitng JSON text from the file into a new List<item> object
        //We will then simply add it to the list, using the Add() method
        existingItemsList.Add(newItem);
        DTOStorage.SerializeItem(existingItemsList);

    }

    public List<Energy> GetEnergyList(User namedUser)
    {
        List<Energy> existingEnergyList = DTOStorage.DeserializeEnergy();
        List<Energy> userEnergylist = new List<Energy>();
        foreach (Energy e in existingEnergyList)
        {
            if (e.owner == namedUser.name)
            {
                userEnergylist.Add(e);
            }
        }

        return userEnergylist;
    }

    public List<Monster> GetMonsterList(User namedUser)
    {
        List<Monster> existingMonsterList = DTOStorage.DeserializeMonster();
        List<Monster> userMonsterlist = new List<Monster>();
        foreach (Monster e in existingMonsterList)
        {
            if (e.owner == namedUser.name)
            {
                userMonsterlist.Add(e);
            }
        }

        return userMonsterlist;
    }

    public List<Item> GetItemList(User namedUser)
    {
        List<Item> existingItemList = DTOStorage.DeserializeItem();
        List<Item> userItemlist = new List<Item>();
        foreach (Item e in existingItemList)
        {
            if (e.owner == namedUser.name)
            {
                userItemlist.Add(e);
            }
        }

        return userItemlist;
    }

    public void UpdateItem(List<Item> updatedList)
    {


        DTOStorage.SerializeItem(updatedList);

    }
    public void UpdateEnergy(List<Energy> updatedList)
    {


        DTOStorage.SerializeEnergy(updatedList);

    }
    public void UpdateMonster(List<Monster> updatedList)
    {


        DTOStorage.SerializeMonster(updatedList);

    }
}
