using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CampusTyconn;

public sealed class GameController : MonoBehaviour
{
    public BaseEvent currentEvent { get; private set; }

    private static GameController instance;

    private CharacterData character;

    private ResourcesController resourcesController;


    public ResourcesController ResourceController
    {
        get
        {
            if (resourcesController == null)
            {
                resourcesController = FindObjectOfType<ResourcesController>();
            }
            return resourcesController;
        }
    }

    public CharacterData characterData
    {
        get
        {
            if (character == null)
            {
                character = InitiliazeCharacterData();
            }
            return character;
        }
        set
        {
            character = value;
        }
    }

    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameController();
            }

            return instance;
        }
    }

    public bool CanCharaterMakeEvent()
    {
        return currentEvent == null;
    }

    public void SetEvent(BaseEvent baseEvent)
    {
        if (currentEvent == null)
        {
            currentEvent = baseEvent;
        }
        else
        {
            Debug.LogWarning("Already event goes on");
        }
    }

    public void SetFreeEvent()
    {
        currentEvent = null;
    }

    public void CreateNewCharacter(CharacterCreationData characterCreationData)
    {
        CharacterData characterData = SaveAndLoadUtility.CreateNewCharacter(characterCreationData);

        SaveAndLoadUtility.SaveCharacterData(characterData);

        this.character = null;

        CharacterCreationScreen characterCreationScreen = FindObjectOfType<CharacterCreationScreen>();

        SetGame(characterCreationScreen.transform);
    }

    public void SetGame(Transform current)
    {
        FindObjectOfType<MainScreensController>().OpenInitiliazationScreen(current);

        FindObjectOfType<MainScreensController>().OpenMainGamePlayScreen(FindObjectOfType<InitilizationScreen>().transform);

        FindObjectOfType<GamePlayScreen>().InitilizaeScreen();

    }

    public Character GetCharacter()
    {
        return DataUtility.GetCharacterData();
    }



    public void SaveCharacterValues(Character character)
    {

    }

    public CharacterData InitiliazeCharacterData()
    {
        return FindObjectOfType<ResourcesController>().GetCharacterData();
    }

    //Save characterData to File when game is quit
    private void OnApplicationQuit()
    {

    }
}

