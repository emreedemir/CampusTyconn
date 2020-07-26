
using System;
namespace CampusTyconn
{
    [Serializable]
    public class Money
    {
        public int moneyAmount;

        public Action<int> OnMoneyAmountChanged;

        public readonly string notEnougMoneyMessage = "No Enough Money";

        public const int defaultValue = 1000;

        public Money()
        {
            moneyAmount = defaultValue;
        }


        public void UpdateMoney(int amount)
        {
            moneyAmount += amount;

            OnMoneyAmountChanged?.Invoke(moneyAmount);
        }

        public bool IsEnoughMoney(int cost)
        {
            return cost < moneyAmount;
        }
    }

    [Serializable]
    public class Debt
    {
        public int debtAmount;

        public Action<int> OnDebtValueChanged;

        public const int defaultValue = 0;

        public Debt()
        {
            debtAmount = defaultValue;
        }

        public void UpdateDebt(int amount)
        {
            debtAmount += amount;

            OnDebtValueChanged?.Invoke(debtAmount);
        }
    }

    [Serializable]
    public class Day
    {
        public int deltaDay;

        public Action<int> OnDayPassed;

        public const int defaultValue = 0;

        public Day()
        {
            deltaDay = defaultValue;
        }

        public void UpdateDay(int amount)
        {
            deltaDay += amount;

            OnDayPassed?.Invoke(deltaDay);      
        }
    }
}

