using session6;
using System;

var coffeeMachine = new CoffeeMachine("black",900, "XL");
var americano = new CoffeeDrink(150M, DrinkName.Americano);
var espresso = new CoffeeDrink(50M, DrinkName.Espresso);
var cappuccino = new CoffeeDrink(375M, DrinkName.Cappuccino);

coffeeMachine.ShowDescription();
Console.WriteLine("____________________________________");
Console.WriteLine("Verification that CoffeMachine is turned off and drink can not be prepared");
try
{
    coffeeMachine.MakeDrink(americano);
}
catch (Exception ex)
{
    Console.WriteLine("Turn on coffee machine. Drink can not be prepared");
    Console.WriteLine($"Error message: {ex.Message}");
    //throw new InvalidOperationException($"Choose the drink to prepare", ex);

}

Console.WriteLine("____________________________________");
Console.WriteLine("Verification that drink can not be null");
try
{
    coffeeMachine.MakeDrink(null);
}
catch (Exception ex)
{
    Console.WriteLine("Please indicate name of the drink you want to prepare");
    Console.WriteLine($"Error message: {ex.Message}");
    //throw new InvalidOperationException($"Choose the drink to prepare", ex);
}


Console.WriteLine("Verification that machine should be turn on and have enough water + you can not add water more that water capacity");
Console.WriteLine("____________________________________");
coffeeMachine.TurnOn();
try
{
    coffeeMachine.AddWater(955M);
}
catch(Exception e)
{
    Console.WriteLine("you want to add more water than your coffee maker can hold");
    Console.WriteLine($"Error message: {e.Message}");
}

coffeeMachine.AddWater(890M);
coffeeMachine.MakeDrink(cappuccino);
coffeeMachine.MakeDrink(cappuccino);
try
{
    coffeeMachine.MakeDrink(cappuccino);
}
catch (Exception ex)
{
    Console.WriteLine("Please add water to prepare drink you want");
    Console.WriteLine($"Error message: {ex.Message}");
}

coffeeMachine.AddWater(300);
coffeeMachine.MakeDrink(cappuccino);

Console.WriteLine("Verification that drink can not be prepared if machine was turned off ");
Console.WriteLine("____________________________________");
try 
{ 
    coffeeMachine.TurnOff(); 
}
catch(Exception e)
{
    Console.WriteLine("Coffee machine was turned off");
    Console.WriteLine($"Error message: {e.Message}");
}

try
{
    coffeeMachine.MakeDrink(americano);
}
catch (Exception e)
{
    Console.WriteLine("Coffee machine was turned off");
    Console.WriteLine($"Error message: {e.Message}");
}
