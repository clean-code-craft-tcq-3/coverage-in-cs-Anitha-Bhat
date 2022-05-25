using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
  public interface IBreachType
  {
    void LogMessage(string recepient);
  }

  public abstract class BreachType
  {
    public abstract void LogMessage(string recepient);
  }

  public class LowBreachType : BreachType
  {
    public override void LogMessage(string recepient)
    {
      Console.WriteLine("To: {}\n", recepient);
      Console.WriteLine("Hi, the temperature is too low\n");
    }
  }

  public class HighBreachType : BreachType
  {
    public override void LogMessage(string recepient)
    {
      Console.WriteLine("To: {}\n", recepient);
      Console.WriteLine("Hi, the temperature is too high\n");
    }
  }
  public class NormalBreachType : BreachType
  {
    public override void LogMessage(string recepient)
    {
     
    }
  }
}
