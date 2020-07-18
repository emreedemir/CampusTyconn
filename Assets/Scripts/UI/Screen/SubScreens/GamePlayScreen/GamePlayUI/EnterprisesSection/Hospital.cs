using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : BaseEnterprise
{
    public BasicButton getTreated;

    public BasicButton getInsurance;

    Character character;

    public override void InitiliazeEnterprise(Character character)
    {
        this.character = character;

        getTreated.OnButtonPressed += OnGetTreatedButtonPressed;

        getInsurance.OnButtonPressed += OnGetInsuranceButtonPressed;
    }

    public void OnGetTreatedButtonPressed()
    {
       
    }

    public void OnGetInsuranceButtonPressed()
    {
        Debug.Log("Get Insurance");
    }
}
