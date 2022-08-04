using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{

  public abstract class BreachType
  {
    private bool _messageSent = false;
    public bool messageSent
    {
      get { return _messageSent; }
      set { _messageSent = value; }
    }

    public abstract void LogMessage(string recepient);
  }

  public class LowBreachType : BreachType
  {

    public override void LogMessage(string recepient)
    {
      Console.WriteLine("To: {}\n"+ recepient);
      Console.WriteLine("Hi, the temperature is too low\n");
       messageSent= true;
    }
  }

  public class HighBreachType : BreachType
  {
    public override void LogMessage(string recepient)
    {
      Console.WriteLine("To: {}\n"+ recepient);
      Console.WriteLine("Hi, the temperature is too high\n");
      messageSent = true;
    }
  }
  public class NormalBreachType : BreachType
  {
    public override void LogMessage(string recepient)
    {
      messageSent = true;
    }
  }
}
