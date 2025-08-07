using System;

namespace session6
{
    public class CoffeeDrink
    {
        public decimal Size { get; set; }
        public DrinkName Name { get; set; }

        public override string ToString() => $"Drink: {Name}, Size: {Size}";

        public CoffeeDrink(decimal size, DrinkName name)
        {
            Size = size;
            Name = name;
        }
    }
}
