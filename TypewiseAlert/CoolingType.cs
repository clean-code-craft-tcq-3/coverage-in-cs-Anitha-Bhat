using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TypewiseAlert
{

  public class CoolingType
  {
    private int _lowerlimit = 0;
    public virtual int lowerLimit
    {
      get
      {
        return _lowerlimit;
      }
      set
      {
        _lowerlimit = value;
      }
    }
    private int _upperlimit = 0;
    public virtual int upperLimit
    {
      get
      {
        return _upperlimit;
      }
      set
      {
        _upperlimit = value;
      }
    }
  };

  public class PassiveCooling : CoolingType
  {
    public override  int lowerLimit=>0;
    public override int upperLimit => 35;
  };

  public class HighActiveCooling : CoolingType
  {
    public override int lowerLimit => 0;
    public override int upperLimit => 45;
  };

  public class MediumActiveCooling : CoolingType
  {
    public override int lowerLimit => 0;
    public override int upperLimit => 40;
  };
}
