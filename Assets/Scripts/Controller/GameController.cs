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

    private void Start()
    {
        SaveAndLoadUtility.CreateRandomCharacter();
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

    public void CreateNewCharacter(CharacterData characterData)
    {
        SaveAndLoadUtility.CreateNewCharacter(characterData);
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

