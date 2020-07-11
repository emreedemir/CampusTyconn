using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialSection : GameSection
{
    public SocialEventButton givePartEventButton;

    public SocialEventButton goConcertEventButton;

    public SocialEventButton meetFirendsEventButton;

    public SocialEventButton goGymEventButton;

    public SocialEventButton goCinemaEventButton;

    public override void InitiliazeSection(Character character)
    {
        givePartEventButton.OnPressed += character.OnPopularityChanged;

        goConcertEventButton.OnPressed += character.OnHappinessChanged;

        meetFirendsEventButton.OnPressed += character.OnRespectChanged;

        goGymEventButton.OnPressed += character.OnHealthChanged;

        goCinemaEventButton.OnPressed += character.OnSelfRealizationChanged;
    }

    public void HandleSocialEvent()
    {

    }
}
