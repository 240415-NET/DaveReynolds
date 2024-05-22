using Project1.Models;
using System.Data;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Project1.Data;

public class DTOStorage
{

    //String representing our file path
    public static string filePath = "Cards.json";



    public static List<Energy> DeserializeEnergy()
    {

        //create empty list of energy card objects
        List<Energy> exisitingEnergyList = new List<Energy>();
        try
        {
            if (File.Exists(filePath))
            {
                //read jsonfile into a string
                string exisitingCardsJson = File.ReadAllText(filePath);
                //format string of text to a DTO with 3 lists of objects
                CardsDTO existingDTO = JsonSerializer.Deserialize<CardsDTO>(exisitingCardsJson);
                //create list of Energy cards from part of DTO
                exisitingEnergyList = existingDTO.Energy.ToList();
            }
            else if (!File.Exists(filePath)) //The first time the program runs, the file probably doesn't exist
            {
                CardsDTO existingDTO = new();
                string existingDTOJson = JsonSerializer.Serialize(existingDTO);
                File.WriteAllText(filePath, existingDTOJson);
            }
        }
        catch (Exception e)
        {

        }

        return exisitingEnergyList;

    }
    public static List<Monster> DeserializeMonster()
    {

        //create empty list of energy card objects
        List<Monster> exisitingMonsterList = new List<Monster>();
        try
        {
            if (File.Exists(filePath))
            {
                //read jsonfile into a string
                string exisitingCardsJson = File.ReadAllText(filePath);
                //format string of text to a DTO with 3 lists of objects
                CardsDTO existingDTO = JsonSerializer.Deserialize<CardsDTO>(exisitingCardsJson);
                //create list of Monster cards from part of DTO
                exisitingMonsterList = existingDTO.Monster.ToList();
            }
            else if (!File.Exists(filePath)) //The first time the program runs, the file probably doesn't exist
            {
                CardsDTO existingDTO = new();
                string existingDTOJson = JsonSerializer.Serialize(existingDTO);
                File.WriteAllText(filePath, existingDTOJson);
            }
        }
        catch (Exception e)
        {

        }

        return exisitingMonsterList;
    }
    public static List<Item> DeserializeItem()
    {
        //create empty list of energy card objects
        List<Item> exisitingObjectList = new List<Item>();
        try
        {
            if (File.Exists(filePath))
            {
                //read jsonfile into a string
                string exisitingCardsJson = File.ReadAllText(filePath);
                //format string of text to a DTO with 3 lists of objects
                CardsDTO existingDTO = JsonSerializer.Deserialize<CardsDTO>(exisitingCardsJson);
                //create list of Object cards from part of DTO
                exisitingObjectList = existingDTO.Item.ToList();
            }
            else if (!File.Exists(filePath)) //The first time the program runs, the file probably doesn't exist
            {
                CardsDTO existingDTO = new();
                string existingDTOJson = JsonSerializer.Serialize(existingDTO);
                File.WriteAllText(filePath, existingDTOJson);
            }
        }
        catch (Exception e)
        {

        }
        return exisitingObjectList;
    }

    public static void SerializeEnergy(List<Energy> exisitingEnergyList)
    {
        //read in DTO file from JSON
        string existingCardsJson = File.ReadAllText(filePath);

        //convert from string to List of Lists
        CardsDTO existingDTO = JsonSerializer.Deserialize<CardsDTO>(existingCardsJson);

        //Replacting exsisiting list with new list with updated item
        existingDTO.Energy = exisitingEnergyList;

        //Reserializing into text for Json
        existingCardsJson = JsonSerializer.Serialize(existingDTO);

        //now save a .json file with file name housed in filePath containing all text of string exisitingCardsJson
        File.WriteAllText(filePath, existingCardsJson);
    }

    public static void SerializeMonster(List<Monster> exisitingMonsterList)
    {
        //read in DTO file from JSON
        string existingCardsJson = File.ReadAllText(filePath);

        //convert from string to List of Lists
        CardsDTO existingDTO = JsonSerializer.Deserialize<CardsDTO>(existingCardsJson);

        //Replacting exsisiting list with new list with updated item
        existingDTO.Monster = exisitingMonsterList;

        //Reserializing into text for Json
        existingCardsJson = JsonSerializer.Serialize(existingDTO);

        //now save a .json file with file name housed in filePath containing all text of string exisitingCardsJson
        File.WriteAllText(filePath, existingCardsJson);
    }
    public static void SerializeItem(List<Item> exisitingItemList)
    {
        //read in DTO file from JSON
        string existingCardsJson = File.ReadAllText(filePath);

        //convert from string to List of Lists
        CardsDTO existingDTO = JsonSerializer.Deserialize<CardsDTO>(existingCardsJson);

        //Replacting exsisiting list with new list with updated item
        existingDTO.Item = exisitingItemList;

        //Reserializing into text for Json
        existingCardsJson = JsonSerializer.Serialize(existingDTO);

        //now save a .json file with file name housed in filePath containing all text of string exisitingCardsJson
        File.WriteAllText(filePath, existingCardsJson);
    }

    public static CardsDTO DeserializeAllCards()
    {
        string exisitingCardsJson = File.ReadAllText(filePath);
                //format string of text to a DTO with 3 lists of objects
                CardsDTO allCards = JsonSerializer.Deserialize<CardsDTO>(exisitingCardsJson);
                //create list of Object cards from part of DTO
               return allCards;
    }

    public static void SerializeAllCards(CardsDTO passedCardsList)
    {
        //serializing list of cards into text for Json
        string existingCardsJson = JsonSerializer.Serialize(passedCardsList);

        //now save a .json file with file name housed in filePath containing all text of string exisitingCardsJson
        File.WriteAllText(filePath, existingCardsJson);
    }

}