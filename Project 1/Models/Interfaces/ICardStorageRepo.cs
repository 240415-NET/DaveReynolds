namespace Project1.Models;

public interface ICardStorageRepo
{
    public void StoreEnergy(Energy newEnergy);
    public void StoreMonster(Monster newMonster);
    public void StoreItem(Item newItem);

    public List<Energy> GetEnergyList(User namedUser);
    public List<Monster> GetMonsterList(User namedUser);
    public List<Item> GetItemList(User namedUser);

    public void UpdateEnergy(List<Energy> updatedList);
    public void UpdateItem(List<Item> updatedList);
    public void UpdateMonster(List<Monster> updatedList);
}