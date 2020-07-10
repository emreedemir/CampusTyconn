using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NameSelection : BaseSelection
{
    public InputField nameInputField;

    public override void Initiliaze()
    {
        Debug.Log("Initliazed");
    }

    public void OnNameFilled()
    {
        string nameAndSurname = nameInputField.text;

        if (nameAndSurname.NameIsRight())
        {
            FindObjectOfType<CharacterCreationScreen>().character.characterName = nameAndSurname;
        }
        else
        {
            Debug.Log("Please fill name correctly");
        }
    }

    public override bool selectionCompleted()
    {
        OnNameFilled();

        return FindObjectOfType<CharacterCreationScreen>().character.characterName.NameIsRight();
    }

    public override void NotCompletedMessage()
    {
        FindObjectOfType<CharacterCreationScreen>().OnMessageReleased("Fill Name Correctly");
    }
}
