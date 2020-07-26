using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CampusTyconn
{
    public class GenderSelection : BaseSelection
    {
        public GenderButton menButton;

        public GenderButton womanButton;

        public Action<Gender> OnGenderSelect;

        public GenderButton selectedGenderButton;

        public override void Initiliaze()
        {
            menButton.gender = Gender.Man;

            menButton.OnClicked += HandleGenderSelection;

            womanButton.gender = Gender.Woman;

            womanButton.OnClicked += HandleGenderSelection;
        }

        public void HandleGenderSelection(GenderButton genderButton)
        {
            if (selectedGenderButton == null)
            {
                selectedGenderButton = genderButton;

            }
            else if (selectedGenderButton != genderButton)
            {
                selectedGenderButton.MarkAsDeselected();

                selectedGenderButton = genderButton;
            }

            selectedGenderButton.MarkAsSelected();

            OnGenderSelect?.Invoke(genderButton.gender);
        }

        public override bool SelectionCompleted(CharacterCreationData characterCreationData)
        {
            if (selectedGenderButton == null)
            {
                OnMessageReleased?.Invoke("Please Select A Gender");

                return false;               
            }
            return characterCreationData.gender.Equals(selectedGenderButton.gender);
        }
    }
    public enum Gender
    {
        None,
        Woman,
        Man
    }
}
