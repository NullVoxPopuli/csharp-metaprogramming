using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace csharp_metaprogramming
{
  [TestClass]
  public class CarTest
  {
    [TestMethod]
    public void Tesla_HasFeatures()
    {
      dynamic expensiveCar = new Examples.Car.Tesla();

      Assert.IsTrue(expensiveCar.HasMoonRoof());
      Assert.IsFalse(expensiveCar.HasFluxCapacitor());
      Assert.IsFalse(expensiveCar.HasGullWingDoors());
      Assert.IsTrue(expensiveCar.HasWindows());
      Assert.IsTrue(expensiveCar.HasTurbo());
    }

    [TestMethod]
    public void Tesla_HasProperties()
    {
      dynamic car = new Examples.Car.Tesla();

      car.Shiny = true;
      car.Electric = true;

      Assert.IsTrue(car.Shiny);
      Assert.IsTrue(car.Electric);
    }
  }
}
