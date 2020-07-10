using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSelection : BaseSelection
{
    public GenderButton menButton;

    public GenderButton womanButton;

    private void Start()
    {
        Initiliaze();
    }

    public override void Initiliaze()
    {
        menButton.gender = Gender.Man;

        menButton.OnClicked += OnGenderSelected;

        womanButton.gender = Gender.Woman;

        womanButton.OnClicked += OnGenderSelected;
    }

    public void OnGenderSelected(Gender gender)
    {
        if (gender == Gender.Man)
        {
            FindObjectOfType<CharacterCreationScreen>().character.characterGender = Gender.Man.ToString();
        }
        else if (gender == Gender.Woman)
        {
            FindObjectOfType<CharacterCreationScreen>().character.characterGender = Gender.Man.ToString();
        }
        else
        {

        }
    }

    public override bool selectionCompleted()
    {
        return (FindObjectOfType<CharacterCreationScreen>().character.characterGender == Gender.Man.ToString()
            || FindObjectOfType<CharacterCreationScreen>().character.characterGender == Gender.Woman.ToString());
    }

    public override void NotCompletedMessage()
    {
        FindObjectOfType<CharacterCreationScreen>().OnMessageReleased("Please Selecte Character");
    }
}
public enum Gender
{
    None,
    Woman,
    Man
}