using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CampusTyconn;
using System;

/// <summary>
/// COMPLETED
/// </summary>
namespace CampusTyconn
{
    public class SocialSection : GameSection
    {
        public List<SocialEventButton> allSocialEventButtons;

        public SocialEventButton socialEventButtonPrefab;

        public Transform listViewParent;

        CharacterData characterData;

        public override void InitiliazeSection(CharacterData characterData)
        {
            this.characterData = characterData;

            List<SocialEvent> socialEvents = FindObjectOfType<ResourcesController>().InitiliazeSocialEvents(characterData);

            allSocialEventButtons = new List<SocialEventButton>();

            for (int i = 0; i < socialEvents.Count; i++)
            {
                SocialEventButton newSocialEventButton = Instantiate(socialEventButtonPrefab);

                newSocialEventButton.transform.SetParent(listViewParent);

                newSocialEventButton.SetSocialEventButton(socialEvents[i]);

                newSocialEventButton.OnPressed += HandleSocialEventSelection;
            }

        }

        public void HandleSocialEventSelection(SocialEventButton socialEventButton)
        {
            SocialEvent social = socialEventButton.socialEvent;

            if (characterData.money.IsEnoughMoney(social.eventCost))
            {
                social.ExecuteEvent();

                characterData.day.UpdateDay(social.eventTime);

                characterData.money.UpdateMoney(social.eventCost);

                socialEventButton.MarkAsPressed();

                ReleaseMessage(social.eventMessage);
            }
            else
            {
                socialEventButton.MarkAsWarning();
                ReleaseMessage("Need more money");
            }
        }

        public override void ReleaseMessage(string message)
        {
            base.OnGameSectionMessageReleased?.Invoke(message);
        }
    }
}
