using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank :BaseEnterprise
{
    public BasicButton getMoneyButton;

    public BasicButton payMoneyButton;

    Character character;

    public override void InitiliazeEnterprise(Character character)
    {
        this.character = character;

        getMoneyButton.OnButtonPressed += OnGetMoneyButtonPressed;

        payMoneyButton.OnButtonPressed += OnPayMoneyButtonPressed;

    }

    public void OnGetMoneyButtonPressed()
    {
        character.SetMoney(100);

        character.SetCreditFee(120);
    }

    public void OnPayMoneyButtonPressed()
    {
        if (character.IsEnoughMoney(100))
        {
            character.SetMoney(-100);
        }
        else
        {
            OnMessageReleased?.Invoke("Not Enough Money");
        }
    }
}
