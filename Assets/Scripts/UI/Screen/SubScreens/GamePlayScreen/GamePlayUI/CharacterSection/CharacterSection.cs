using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSection : GameSection, ICharacterObserver
{
    public Text moneyText;

    public Text timeText;

    public Text creditFeeText;

    public Text gradeText;

    public Text selfEsteemText;

    public Text happinessText;

    public override void InitiliazeSection()
    {

    }

    public void Update(Character character)
    {
        moneyText.text = "" + character.money;

        timeText.text = "" + character.deltaDay;

        creditFeeText.text = "" + character.creditFee;

        gradeText.text = "" + 3;

        selfEsteemText.text = "" + character.selfRealization;

        happinessText.text = "" + character.morela;
    }
}
