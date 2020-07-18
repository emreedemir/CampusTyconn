using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenderSelection : BaseSelection
{
    public GenderButton menButton;

    public GenderButton womanButton;

    public List<GenderButton> genderButtons;

    public Action<Gender> OnGenderSelected;

    public Action<string> OnNotSelected;

    public GenderButton selectedGenderButton;

    public override void Initiliaze()
    {
        menButton.gender = Gender.Man;

        menButton.OnClicked += OnGenderSelected;

        womanButton.gender = Gender.Woman;

        womanButton.OnClicked += OnGenderSelected;
    }

    public void HandleGenderSelection(GenderButton genderButton)
    {
        if (selectedGenderButton == null)
        {
            selectedGenderButton = genderButton;

            //selectedGender Button Mark As Selected
        }
        else if (selectedGenderButton != genderButton)
        {
            //selctedGender Button mark as Deselected
            selectedGenderButton = genderButton;
        }

        //genderButton.MarkAsSelected();

        OnGenderSelected?.Invoke(genderButton.gender);
    }

    public override bool selectionCompleted()
    {
        return selectedGenderButton != null;
    }

    public override void NotCompletedMessage()
    {
        OnNotSelected?.Invoke("Please Selecte a Gender");
        FindObjectOfType<CharacterCreationScreen>().OnMessageReleased("Please Select Gender");
    }
}
public enum Gender
{
    None,
    Woman,
    Man
}