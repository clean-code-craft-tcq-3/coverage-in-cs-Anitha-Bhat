using System;

namespace TypewiseAlert
{
  public class TypewiseAlert
  {

    public struct BatteryCharacter
    {
      public CoolingType coolingType;
      public string brand;
    }

    public static BreachType inferBreach(double value, double lowerLimit, double upperLimit) {
      if(value < lowerLimit) {
       return new LowBreachType();
      }
      if(value > upperLimit) {
       return new HighBreachType();
      }
      return new NormalBreachType();
    }

    public static BreachType classifyTemperatureBreach(CoolingType coolingType, double temperatureInC) {
      return inferBreach(temperatureInC, coolingType.lowerLimit, coolingType.upperLimit) ;
    }


    public static void checkAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar,double temperatureInC) {

      BreachType breachType = classifyTemperatureBreach(batteryChar.coolingType,temperatureInC);

      alertTarget.SendTarget(breachType);
    }
   

  }
}
