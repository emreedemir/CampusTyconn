using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterController : MonoBehaviour
{
    public Character currentCharacter;

    public List<ICharacterObserver> allObservers;

    public Action<int> OnHealthChanged;

    public Action<int> OnHappinessChanged;

    public Action<int> OnMoneyChanged;

    public Action<int> OnTimeChanged;
    

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

    }

    void DayPass()
    {

    }

    public void OnCharacterFinishProgress()
    {

    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;

    }
}
