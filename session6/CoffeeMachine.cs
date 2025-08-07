namespace session6
{
    public class CoffeeMachine
    {
        public string Color { set; get; }
        public decimal MaxVolume { get; set; }
        public decimal WaterVolume { get; set; }
        public string ModelName { get; set; }
        private bool IsOn { get; set; }

        public CoffeeMachine(string color, decimal volume, string modelName)
        {
            Color = color;
            MaxVolume = volume;
            ModelName = modelName;
        }

        public void MakeDrink(CoffeeDrink drink)
        {
            ValidateParameters(drink);

            if (WaterVolume >= drink.Size)
            {
                WaterVolume -= drink.Size;
                Console.WriteLine($"You have enough water, size of your {drink.Name} is {drink.Size} ml. Wait until your drink is ready and enjoy!");
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(drink.Size), $"You do not have enough water.Please fill the container with water");
            }
        }

        private void ValidateParameters(CoffeeDrink drink)
        {
            if (drink == null) //// conver to switch
            {
                throw new ArgumentOutOfRangeException(nameof(drink), "Indicate name of the drink, you want to prepare.");
            }
            if (!IsOn)
            {
                throw new ArgumentOutOfRangeException(nameof(IsOn), "Turn on coffee machine. Drink can not be prepared");
            }
        }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Machine turns on. Wait 2 min before start prepare the drink");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine("Machine turns off.");
        }

        public void AddWater(decimal addedWater)
        {
            decimal tmpWater = WaterVolume + addedWater;
            if (tmpWater > MaxVolume)
            {
                throw new ArgumentOutOfRangeException(nameof(tmpWater),"you want add a lot of water.");
            }
            WaterVolume = tmpWater;
            Console.WriteLine($"You added water. Coffemachine is ready to prepare the drink");
        }

        public void ShowDescription()
        {
            Console.WriteLine($"Thank you for buying Coffe Machine. It has the following parameters: color {Color}, water volume {MaxVolume} and name of the model is {ModelName} ");
        }
    }

}
