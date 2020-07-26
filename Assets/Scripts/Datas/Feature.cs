namespace CampusTyconn
{
    using System;
    using UnityEngine;
    public abstract class Feature
    {
        public int featureValue;

        public const int maximum = 100;

        public const int minumun = 0;

        public string featureName;

        public Action<int> OnFeatureUpdated;

        public bool IsMaximum()
        {
            return featureValue >= maximum;
        }

        public void AddValue(int value)
        {
            featureValue = GetValue(value);

            if (OnFeatureUpdated == null)
            {
                Debug.Log("Action is null");
            }
            else
            {
                Debug.Log("Action not null çagrılmalı");
            }
            OnFeatureUpdated?.Invoke(featureValue);
        }

        private int GetValue(int plusValue)
        {
            if (featureValue + plusValue > maximum)
            {
                return maximum;
            }
            else if (featureValue + plusValue <= 0)
            {
                return 0;
            }
            else
            {
                return featureValue + plusValue;
            }
        }
    }

    [Serializable]
    public class Health : Feature
    {
        public const int defaultStartValue = 50;

        public Health()
        {
            base.featureName = "Health";
            base.featureValue = defaultStartValue;
        }
    }

    [Serializable]
    public class Happiness : Feature
    {
        public const int maximumValue = 100;

        public const int defaultStartValue = 50;

        public Happiness()
        {
            base.featureName = "Happiness";
            base.featureValue = defaultStartValue;
        }
    }

    [Serializable]
    public class Popularity : Feature
    {
        public const int maximumValue = 100;

        public const int defaultStartValue = 50;

        public Popularity()
        {
            base.featureName = "Popularity";
            base.featureValue = defaultStartValue;
        }
    }

    [Serializable]
    public class Respect : Feature
    {
        public const int maximumValue = 100;

        public const int defaultStartValue = 50;

        public Respect()
        {
            base.featureName = "Respect";
            base.featureValue = defaultStartValue;
          
        }
    }

    [Serializable]
    public class SelfRealization : Feature
    {
        public const int maximumValue = 100;

        public const int defaultStartValue = 50;

        public SelfRealization()
        {
            base.featureName = "Self Realization";
            base.featureValue = defaultStartValue;
        }
    }
}

