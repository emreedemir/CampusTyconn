using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CampusTyconn;
using System;

namespace CampusTyconn
{
    public class SocialSection : GameSection
    {
        public List<SocialEventButton> allSocialEventButtons;

        public SocialEventButton socialEventButtonPrefab;

        public Transform listViewParent;

        CharacterData charData;

        public Action<BaseEvent> OnEventStarted;

        public Action<BaseEvent> OnEventEnded;

        public Action<string> OnMessageReleased;

        public override void InitiliazeSection(CharacterData characterData)
        {
            List<SocialEvent> socialEvents = FindObjectOfType<ResourcesController>().allSocialEvents;

            Debug.Log("SocialEvent" + socialEvents.Count);

            for (int i = 0; i < socialEvents.Count; i++)
            {
                SocialEventButton socialEventButton = Instantiate(socialEventButtonPrefab);

                socialEventButton.SetSocialEventButton(socialEvents[i]);

                socialEventButton.OnPressed += HandleSocialEventStart;

                socialEvents[i].OnEventMessageReleased += HandleSocialEventMessage;

                socialEvents[i].OnEventStarted += HandleSocialEventStarted;

                socialEventButton.transform.SetParent(listViewParent);

                allSocialEventButtons.Add(socialEventButton);
            }

            allSocialEventButtons = new List<SocialEventButton>();
        }

        public void HandleSocialEventStart(SocialEvent socialEvent)
        {
            socialEvent.ExecuteEvent(charData);
        }

        public void HandleSocialEventStarted(SocialEvent socialEvent)
        {
            allSocialEventButtons.Find(x => x.Equals(socialEvent)).StartEventForButton();

            OnEventStarted?.Invoke(socialEvent);
        }

        public void HandleSocialEventEnd(SocialEvent socialEvent)
        {
            SocialEventButton socialEventButton = allSocialEventButtons.Find(x => x.Equals(socialEvent));

            socialEventButton.EndEventForButton();

            OnEventEnded?.Invoke(socialEvent);
        }

        public void HandleSocialEventMessage(string message)
        {
            OnMessageReleased?.Invoke(message);
        }

        public void HandleSocialEventSelection(SocialEvent socialEvent)
        {
            socialEvent.ExecuteEvent(charData);
        }
    }
}
