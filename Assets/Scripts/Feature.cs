namespace CampusTyconn
{
    using System;

    public abstract class Feature
    {
        protected int feautureValue;

        protected int maximum;

        public Action<int> OnFeatureUpdated;


        public bool IsMaximum()
        {
            return feautureValue >= maximum;
        }

        public void AddValue(int value)
        {
            feautureValue = GetValue(value);

            OnFeatureUpdated?.Invoke(feautureValue);
        }

        private int GetValue(int plusValue)
        {
            if (feautureValue + plusValue > maximum)
            {
                return maximum;
            }
            else if (feautureValue + plusValue <= 0)
            {
                return 0;
            }
            else
            {
                return feautureValue + plusValue;
            }
        }
    }

    [Serializable]
    public class Health : Feature
    {
        public const int maximumValue= 100;

        public const int defaultStartValue =50;

        public int currentValue;

        public Health()
        {
            currentValue = defaultStartValue;
        }
    }

    [Serializable]
    public class Money : Feature
    {
        public const int maximumValue = 1000000;

        public const int defaultStartValue = 1000;

        public readonly string notEnoughMessage = "Not Enough Money";

        public int currentValue;

        public Money()
        {
            currentValue = defaultStartValue;
        }

        public bool IsEnough(int cost)
        {
            return cost < base.feautureValue;
        }
    }

    [Serializable]
    public class Happiness : Feature
    {
        public const int maximumValue = 100;

        public const int defaultStartValue = 50;

        public int currentValue;

        public Happiness()
        {
            currentValue = defaultStartValue;
        }
    }

    [Serializable]
    public class Popularity : Feature
    {
        public const int maximumValue = 100;

        public const int defaultStartValue = 50;

        public int currentValue;

        public Popularity()
        {
            currentValue = defaultStartValue;
        }
    }

    [Serializable]
    public class Respect : Feature
    {
        public const int maximumValue = 100;

        public const int defaultStartValue = 50;

        public int currentValue;

        public Respect()
        {
            currentValue = defaultStartValue;
        }
    }

    [Serializable]
    public class SelfRealization : Feature
    {
        public const int maximumValue = 100;

        public const int defaultStartValue = 50;

        public int currentValue;

        public SelfRealization()
        {
            currentValue = defaultStartValue;
        }

    }
    [Serializable]
    public class Credit : Feature
    {
        public const int maximumValue = 100;

        public const int defaultStartValue = 0;

        public int currentValue;

        public Credit()
        {
            currentValue = defaultStartValue;
        }
    }
    [Serializable]
    public class Day : Feature
    {
        public const int maximumValue = 10000;

        public const int defaultStartValue = 0;

        public int currentValue = 0;

        public Day()
        {
            currentValue = defaultStartValue;
        }
    }
}

