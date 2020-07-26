using System.Collections;
using System.Collections.Generic;
using CampusTyconn;
using UnityEngine;
using System.IO;

public static class SaveAndLoadUtility
{
    public static void SaveCharacterData(CharacterData characterData)
    {
        string characterStringFile = JsonUtility.ToJson(characterData, true);

        string dataPathForCharacterData = Application.dataPath + "/Resources/CharacterData/" + "characterDataFile.json";

        File.WriteAllText(dataPathForCharacterData, characterStringFile);
    }

    public static CharacterData LoadCharacterData()
    {
        return new CharacterData();
    }

    public static void CreateRandomCharacter()
    {
        CharacterData characterData = new CharacterData();

        characterData.debt = new Debt();

        characterData.happiness = new Happiness();

        characterData.money = new Money();

        characterData.health = new Health();

        characterData.respect = new Respect();

        characterData.popularity = new Popularity();


        characterData.gender = Gender.Man;

        characterData.happiness = new Happiness();

        characterData.selfRealization = new SelfRealization();

        characterData.day = new Day();

        characterData.name = "Mesude Can";

        string characterStringFile = JsonUtility.ToJson(characterData, true);

        string dataPathForCharacterData = Application.dataPath + "/Resources/CharacterData/" + "characterDataFile.json";

        File.WriteAllText(dataPathForCharacterData, characterStringFile);

    }

    public static CharacterData CreateNewCharacter(CharacterCreationData characterCreationData)
    {
        CharacterData characterData = GetDefaultCharacter();

        characterData.gender = characterCreationData.gender;

        characterData.name = characterCreationData.name;

        characterData.department = characterCreationData.department;

        return characterData;
    }

    private static CharacterData GetDefaultCharacter()
    {
        CharacterData characterData = new CharacterData();

        characterData.debt = new Debt();

        characterData.happiness = new Happiness();

        characterData.money = new Money();

        characterData.health = new Health();

        characterData.respect = new Respect();

        characterData.popularity = new Popularity();

        characterData.gender = Gender.Man;

        characterData.happiness = new Happiness();

        characterData.selfRealization = new SelfRealization();

        characterData.day = new Day();

        characterData.name = "Mesude Can";

        return characterData;
    }
}
