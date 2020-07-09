using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScreen : MonoBehaviour
{
    public BasicButton characterButton;

    public BasicButton schoolButton;

    public BasicButton socialButton;

    public BasicButton enterpriseButton;

    public BasicButton exitToMainButton;


    public void InitiliazeMainCharacterScreen()
    {
        characterButton.OnButtonPressed += OnCharacterButtonPressed;

        schoolButton.OnButtonPressed += OnSchoolButtonPressed;

        enterpriseButton.OnButtonPressed += OnJobButtonPressed;

        socialButton.OnButtonPressed += OnSocialButtonPressed;

    }

    public void OnCharacterButtonPressed()
    {
       
    }

    public void OnJobButtonPressed()
    {

    }

    public void OnSchoolButtonPressed()
    {

    }

    public void OnSocialButtonPressed()
    {

    }

    public void OnEnterpriseButtonPressed()
    {

    }
}
