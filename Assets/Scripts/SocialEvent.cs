namespace CampusTyconn
{
    using System;
    using System.Collections.Generic;

    public sealed class SocialEvent : BaseEvent
    {
        public string eventName { get; set; }

        public int eventTime { get; set; }

        public int eventCost { get; set; }

        public string eventMessage { get; set; }

        public Action<string> OnEventMessageReleased { get; set; }

        public Action<SocialEvent> OnEventStarted { get; set; }

        public Dictionary<Feature, int> targetFeatures;

        public SocialEvent()
        {
            this.targetFeatures = new Dictionary<Feature, int>();
        }

        public void AddTargetFeature(Feature targetFeature, int plusValue)
        {
            targetFeatures.Add(targetFeature, plusValue);
        }

        public override void ExecuteEvent(CharacterData character)
        {
            if (character.money.IsEnough(eventCost))
            {
                EventMessage(eventMessage);

                foreach (KeyValuePair<Feature, int> pair in targetFeatures)
                {
                    pair.Key.AddValue(pair.Value);
                }

                OnEventStarted?.Invoke(this);
            }
            else
            {
                EventMessage(character.money.notEnoughMessage);
            }
        }

        public void EventMessage(string message)
        {
            OnEventMessageReleased?.Invoke(message);
        }
    }

    public static class SocialEventBuilder
    {
        public static SocialEvent CreateNewEvent()
        {
            return new SocialEvent();
        }

        public static SocialEvent SetEventName(this SocialEvent socialEvent, string eventName)
        {
            socialEvent.eventName = eventName;
            return socialEvent;
        }

        public static SocialEvent SetEventCost(this SocialEvent socialEvent, int eventCost)
        {
            socialEvent.eventCost = eventCost;
            return socialEvent;
        }

        public static SocialEvent SetEventMessage(this SocialEvent socialEvent, string eventMessage)
        {
            socialEvent.eventMessage = eventMessage;
            return socialEvent;
        }

        public static SocialEvent AddTargetFeatureToEvent(this SocialEvent socialEvent, KeyValuePair<Feature, int> featureAndPlusValue)
        {
            socialEvent.AddTargetFeature(featureAndPlusValue.Key, featureAndPlusValue.Value);
            return socialEvent;
        }
    }
}

