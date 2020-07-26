using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace CampusTyconn
{
    public class NameSelection : BaseSelection
    {
        public InputField nameInputField;

        public Action<string> OnNameFill;

        public override void Initiliaze()
        {
            Debug.Log("Initliazed");

            nameInputField.onEndEdit.AddListener(fieldValue =>
            {
                if (!nameInputField.text.NameIsRight())
                {
                    OnMessageReleased?.Invoke("Please Fill Name Correctly");
                }
                else
                {
                    OnNameFill?.Invoke(nameInputField.text);
                }
            });
        }

        public override bool SelectionCompleted(CharacterCreationData characterCreationData)
        {
            if (!characterCreationData.name.NameIsRight())
            {
                OnMessageReleased?.Invoke("Please Fill Name");
                return false;
            }

            return characterCreationData.name == nameInputField.text;
        }
    }
}
