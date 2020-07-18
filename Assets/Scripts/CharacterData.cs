using System;

namespace CampusTyconn
{
    [Serializable]
    public class CharacterData
    {
        public string name;

        public Gender gender;

        public Money money;

        public Happiness happiness;

        public Popularity popularity;

        public Respect respect;

        public SelfRealization selfRealization;

        public Health health;

        public Credit credit;

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

            credit = new Credit();

            day = new Day();

            department = new Department();
        }

        public CharacterData(Money money, Happiness happiness, Popularity popularity, Respect respect, SelfRealization selfRealization, Health health, Credit credit, Day day)
        {
            this.money = money;
            this.happiness = happiness;
            this.popularity = popularity;
            this.respect = respect;
            this.selfRealization = selfRealization;
            this.health = health;
            this.credit = credit;
            this.day = day;
        }
    }
}
