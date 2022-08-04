using Moq;
using System;
using Xunit;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
    [Fact]
    public void InfersBreachAsPerLimits()
    {
      Assert.True(TypewiseAlert.inferBreach(12, 20, 30) is LowBreachType);
      Assert.True(TypewiseAlert.inferBreach(35, 20, 30) is HighBreachType);
      Assert.True(TypewiseAlert.inferBreach(25, 20, 30) is NormalBreachType);
      Assert.True(TypewiseAlert.classifyTemperatureBreach(new PassiveCooling(), 50) is HighBreachType);
      Assert.True(TypewiseAlert.classifyTemperatureBreach(new PassiveCooling(), 25) is NormalBreachType);
      Assert.True(TypewiseAlert.classifyTemperatureBreach(new HighActiveCooling(), 50) is HighBreachType);
      Assert.True(TypewiseAlert.classifyTemperatureBreach(new HighActiveCooling(), -1) is LowBreachType);
      Assert.True(TypewiseAlert.classifyTemperatureBreach(new MediumActiveCooling(), 50) is HighBreachType);
      Assert.True(TypewiseAlert.classifyTemperatureBreach(new MediumActiveCooling(), 30) is NormalBreachType);

      var alertTarget = new Mock<AlertTarget>();
      var batteryChar1 = new TypewiseAlert.BatteryCharacter() { coolingType = new PassiveCooling() };

      TypewiseAlert.checkAndAlert(alertTarget.Object, batteryChar1, 25);
      alertTarget.Verify(func => func.SendTarget(It.IsAny<NormalBreachType>()),Times.Exactly(1));

      var batteryChar2 = new TypewiseAlert.BatteryCharacter() { coolingType = new HighActiveCooling() };

      TypewiseAlert.checkAndAlert(alertTarget.Object, batteryChar2, 50);
      alertTarget.Verify(func => func.SendTarget(It.IsAny<HighBreachType>()), Times.Exactly(1));

      var batteryChar3 = new TypewiseAlert.BatteryCharacter() { coolingType = new HighActiveCooling() };

      TypewiseAlert.checkAndAlert(alertTarget.Object, batteryChar3, -1);
      alertTarget.Verify(func => func.SendTarget(It.IsAny<LowBreachType>()), Times.Exactly(1));

      var passiveCooling = new PassiveCooling();
      Assert.Equal(0,passiveCooling.lowerLimit);
      Assert.Equal(35,passiveCooling.upperLimit);

      var highActiveCooling = new HighActiveCooling();
      Assert.Equal(0, highActiveCooling.lowerLimit);
      Assert.Equal(45, highActiveCooling.upperLimit);

      var mediumActiveCooling = new MediumActiveCooling();
      Assert.Equal(0, mediumActiveCooling.lowerLimit);
      Assert.Equal(40, mediumActiveCooling.upperLimit);
    }
  }
}
