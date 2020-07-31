using System;
using System.Collections.Generic;

namespace CampusTyconn
{
    [Serializable]
    public class CharacterData
    {
        public string name;

        public Gender gender;

        public Feature[] features;

        public Money money;

        public Happiness happiness;

        public Popularity popularity;

        public Respect respect;

        public SelfRealization selfRealization;

        public Health health;

        public Debt debt;

        public Day day;

        public Department department;

        public CharacterData()
        {
            name = "";

            gender = Gender.None;

            money = new Money();

            happiness = new Happiness();

            popularity = new Popularity();

            respect = new Respect();

            selfRealization = new SelfRealization();

            health = new Health();

            debt = new Debt();

            day = new Day();

            department = new Department();
        }

        public CharacterData(Money money, Debt debt, Day day, Happiness happiness, Popularity popularity, Respect respect, SelfRealization selfRealization, Health health)
        {
            this.money = money;
            this.happiness = happiness;
            this.popularity = popularity;
            this.respect = respect;
            this.selfRealization = selfRealization;
            this.health = health;
            this.debt = debt;
            this.day = day;
        }

        public List<Feature> GetAllFeatures()
        {
            return new List<Feature>() { happiness, popularity, respect, selfRealization, health };
        }
    }
}
