
using System;

[Serializable]
public class Character
{
    public string characterName { get; private set; }

    public string characterGender { get; private set; }

    /// <summary>
    /// Characte Self Values
    /// </summary>
    public int health { get; private set; }

    public int respect { get; private set; }

    public int selfRealization { get; private set; }

    public int happiness { get; private set; }

    public int popularity { get; private set; }

    public Action<int> OnHealthChanged;

    public Action<int> OnRespectChanged;

    public Action<int> OnSelfRealizationChanged;

    public Action<int> OnHappinessChanged;

    public Action<int> OnPopularityChanged;

    public Action<int> OnMoneyChanged;

    public Action<int> OnCreditFeeChanged;

    /// <summary>
    /// Character Non Self Values
    /// </summary>
    public int money { get; private set; }

    public int deltaDay { get; private set; }

    public Country country { get; private set; }

    public Department department { get; private set; }

    public int creditFee { get; private set; }

    public Character()
    {
        creditFee = 0;
        health = 50;
        popularity = 50;
        respect = 50;
        selfRealization = 50;
        money = 100000;
    }

    public void SetCountry(Country country)
    {
        this.country = country;
    }

    public void SetNameAndSurname(string nameAndSurname)
    {
        this.characterName = nameAndSurname;
    }

    public void SetDepartment(Department department)
    {
        this.department = department;
    }

    public void SetGender(string gender)
    {
        this.characterGender = gender;
    }

    public void SetHealth(int changeValue)
    {
        if (health + changeValue > 100)
        {
            health = 100;
        }
        else if (health + changeValue < 0)
        {
            health = 0;
        }
        else
        {
            health += changeValue;
        }

        OnHealthChanged?.Invoke(health);

    }

    public void SetMoney(int changedValue)
    {
        money += changedValue;

        OnMoneyChanged?.Invoke(money);
    }

    public void SetHappiness(int changedValue)
    {
        if (happiness + changedValue > 100)
        {
            happiness = 100;
        }
        else if (happiness + changedValue < 0)
        {
            happiness = 0;
        }
        else
        {
            happiness += changedValue;
        }

        OnHappinessChanged?.Invoke(happiness);
    }

    public void SetSelfRealization(int changedValue)
    {
        if (selfRealization + changedValue < 0)
        {
            selfRealization = 0;
        }
        else if (selfRealization + changedValue > 100)
        {
            selfRealization = 100;
        }
        else
        {
            selfRealization += changedValue;
        }

        OnSelfRealizationChanged?.Invoke(selfRealization);
    }


    public void SetRespect(int value)
    {
        if (respect + value > 100)
        {
            respect = 100;
        }
        else if (respect + value < 0)
        {
            respect = 0;
        }
        else
        {
            respect += value;
        }

        OnRespectChanged?.Invoke(respect);
    }

    public void SetPopularity(int changeValue)
    {
        if (popularity + changeValue < 0)
        {
            popularity = 0;
        }
        else if (popularity + changeValue > 100)
        {
            popularity = 100;
        }
        else
        {
            popularity += changeValue;
        }

        OnPopularityChanged?.Invoke(popularity);
    }

    public void CourseWorked(Course course)
    {

    }

    public bool IsEnoughMoney(int amount)
    {
        return amount < money;
    }

    public void SetCreditFee(int amount)
    {
        if (creditFee + amount < 0)
        {
            creditFee = 0;
        }

        creditFee += amount;

        OnCreditFeeChanged?.Invoke(creditFee);
    }

    public bool IsCreditFee()
    {
        return creditFee > 0;
    }
}
