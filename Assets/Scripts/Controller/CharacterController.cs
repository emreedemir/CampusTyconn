using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Character currentCharacter;

    public List<ICharacterObserver> allObservers;
    

    public void SetCharacter()
    {
        currentCharacter = FindObjectOfType<GameController>().GetCharacter();
    }
    
    public void NotifyObservers()
    {
        allObservers.ForEach(x => x.Update(currentCharacter));
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
}
