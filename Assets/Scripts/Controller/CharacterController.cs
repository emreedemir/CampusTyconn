using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterController : MonoBehaviour
{
    public Character currentCharacter;

    public List<ICharacterObserver> allObservers;

    public bool InProgress;

    public void SetCharacter()
    {
        currentCharacter = FindObjectOfType<GameController>().GetCharacter();
    }
    
    public void NotifyObservers()
    {
        allObservers.ForEach(x => x.UpdateCharacterValues(currentCharacter));
    }

    private void OnApplicationQuit()
    {
        FindObjectOfType<GameController>().SaveCharacterValues(currentCharacter);
    }

    public void OnCharacterProgress()
    {
        InProgress = true;
    }

    public void OnCharacterFinishProgress()
    {
        InProgress = false;
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;

    }
}
