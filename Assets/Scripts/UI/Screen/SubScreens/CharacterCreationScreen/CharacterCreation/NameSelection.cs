using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NameSelection : BaseSelection
{
    public InputField nameInputField;

    public Action<string> OnNameFilled;

    public Action<string> OnMessageReleased;

    public override void Initiliaze()
    {
        Debug.Log("Initliazed");
    }

    public void HandleNameFill()
    {
        
        string nameAndSurname = nameInputField.text;

        if (nameAndSurname.NameIsRight())
        {
            OnNameFilled?.Invoke(nameAndSurname);
        }
        else
        {
            OnMessageReleased?.Invoke("Please Fill Name");
        }
    }

    public override bool selectionCompleted()
    {

        //input event lere bak
        return FindObjectOfType<CharacterCreationScreen>().character.characterName.NameIsRight();
    }

    public override void NotCompletedMessage()
    {
        OnMessageReleased?.Invoke("Fill Name Correctly");
    }
}
