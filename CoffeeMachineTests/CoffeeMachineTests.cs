namespace CoffeeMachineTests;
using session6;
using System;


public class CoffeeMachineTests
{


    [SetUp]
    public void Setup()
    {
    }


    //[Test]
    //public void AddWaterTest()
    //{
    //    var addedVolume = 10;
    //    var expectedVolume = 10;
    //    var coffeeMachine = new CoffeeMachine("black", 25, "XL");
    //    coffeeMachine.AddWater(addedVolume);
    //    Assert.That(coffeeMachine.WaterVolume, Is.EqualTo(expectedVolume));

    //}

    [TestCase(10, 10)]
    [TestCase(25, 25)]
    public void AddWaterTest(decimal addedVolume, decimal expectedVolume)
    {
        var coffeeMachine = new CoffeeMachine("black", 25, "XL");

        coffeeMachine.AddWater(addedVolume);

        Assert.That(coffeeMachine.WaterVolume, Is.EqualTo(expectedVolume));
    }


    [Test]
    [TestCase(10)]
    [TestCase(5.01)]   
    public void AddWater_WhenOverflow_ShouldThrow(decimal addedVolume)
    {
        var coffeeMachine = new CoffeeMachine("black", 5m, "XL");
        Assert.Throws<ArgumentOutOfRangeException>(
            () => coffeeMachine.AddWater(addedVolume));
    }

    [Test]

    public void MakeDrink_Positive()
    {
        var coffeeDrink = new CoffeeDrink(5, DrinkName.Cappuccino);
        var coffeeMachine = new CoffeeMachine("black", 25, "XL");
        var addedVolume = 10;
        var expectedVolume = 5;
        coffeeMachine.TurnOn();
        coffeeMachine.AddWater(addedVolume);
        coffeeMachine.MakeDrink(coffeeDrink);
        Assert.That(coffeeMachine.WaterVolume, Is.EqualTo(expectedVolume));
    }

    [Test]
    public void MakeDrink_Verify_DrinkSize()
    {
        var coffeeDrink = new CoffeeDrink(30, DrinkName.Cappuccino);
        var coffeeMachine = new CoffeeMachine("black", 25, "XL");
        var addedVolume = 25 ;
        //var expectedVolume = 5;
        coffeeMachine.TurnOn();
        coffeeMachine.AddWater(addedVolume);
        Assert.Throws<ArgumentOutOfRangeException>(delegate { coffeeMachine.MakeDrink(coffeeDrink); });
    }
}
