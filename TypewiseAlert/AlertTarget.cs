using System;

namespace TypewiseAlert
{
  public interface IAlertTarget
  {
   void SendTarget(BreachType breachType);
  }

  public abstract class AlertTarget
  {
    public abstract void SendTarget(BreachType breachType);
  }


  public class Controller:AlertTarget
  {
    public override void SendTarget(BreachType breachType)
    {
      const ushort header = 0xfeed;
      Console.WriteLine("{} : {}\n", header, breachType);
    }
      
  }

  public class Email : AlertTarget
  {
    public override void SendTarget(BreachType breachType)
    {
      string recepient = "a.b@c.com";
      breachType.LogMessage(recepient);
     
    }
  }
}