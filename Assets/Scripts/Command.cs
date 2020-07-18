using System.Collections;
namespace CampusTyconn
{
    public abstract class Command
    {
        public abstract void ExecuteCommand(Character character);
    }

    public class GetTreat : Command
    {
        public override void ExecuteCommand(Character character)
        {
            character.SetHealth(10);
        }
    }

    public class GetInsurance : Command
    {
        public override void ExecuteCommand(Character character)
        {
           
        }
    }
}
