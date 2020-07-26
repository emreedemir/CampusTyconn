namespace CampusTyconn
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public sealed class SocialEvent : BaseEvent
    {
        public string eventName { get; set; }

        public int eventTime { get; set; }

        public int eventCost { get; set; }

        public string eventMessage { get; set; }

        public Dictionary<Feature, int> targetFeatures;

        public SocialEvent()
        {
            this.targetFeatures = new Dictionary<Feature, int>();
        }

        public void AddTargetFeature(Feature targetFeature, int plusValue)
        {
            targetFeatures.Add(targetFeature, plusValue);
        }

        public override void ExecuteEvent()
        {
            foreach (KeyValuePair<Feature, int> pair in targetFeatures)
            {
                pair.Key.AddValue(pair.Value);
            }
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

