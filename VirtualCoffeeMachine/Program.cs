

using VirtualCoffeeMachine.Helpers;
using VirtualCoffeeMachine.Models;
using VirtualCoffeeMachine.Models.Coins;

public class Program
{
    public static async Task Main(string[] args)
    {
        var allCoins = CoinHelper.CreateCoins();
        var allCoffeeChoices = CoffeeHelper.CreateCoffees();

        Program program = new Program();
        await program.CoffeeMenu(allCoffeeChoices, allCoins);
        Console.ReadKey();
    }

    public async Task CoffeeMenu(List<CoffeeModel> CoffeeOptions, List<CoinModel> CoinOptions)
    {
        Console.WriteLine("\nCoffee Shop Menu Options are: ");

        // Listing all of the coffee options
        foreach (var coffee in CoffeeOptions)
        {
            Console.WriteLine(coffee.ToString());
        }

        Console.Write("\nSelect your Coffee: ");
        int input = Convert.ToInt32(Console.ReadLine());
        // select a coffee option by input
        switch (input)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                Console.WriteLine($"Customer Selected {CoffeeOptions[0].Name}");
                PayForCoffee(CoffeeOptions[0], CoinOptions);
                await CappuccinoInstructions();
                break;
            case 2:
                Console.WriteLine($"Customer Selected {CoffeeOptions[1].Name}");
                PayForCoffee(CoffeeOptions[1], CoinOptions);
                await LatteInstructions();
                break;
            case 3:
                Console.WriteLine($"Customer Selected {CoffeeOptions[2].Name}");
                PayForCoffee(CoffeeOptions[2], CoinOptions);
                await DecafInstructions();
                break;
            default:
                Console.WriteLine("Input Coffee Option");
                await CoffeeMenu(CoffeeOptions, CoinOptions);
                break;
        }
    }

    /// <summary>
    /// This method handles giving coins to the machine and getting the required changed back from the machine if the value isn't exactly the same as the cost of the coffee
    /// </summary>
    public static void PayForCoffee(CoffeeModel Coffee, List<CoinModel> Coins)
    {
        var coffeePrice = Coffee.Price;
        double totalCoins = Math.Round(0.00, 2);

        Console.WriteLine("\nList of avaliable coins");

        foreach (var options in Coins)
        {
            Console.WriteLine(options.Id + ": " + options.Coins + " " + options.Type);
        }

        // while the totalCoins price is less the the coffeePrice then stay into this loop,
        // this loop is designed to insert your coins into the coffee machine 
        while (totalCoins < coffeePrice)
        {
            Console.Write("\nInsert Coin: ");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("This machine does not take 1 cent coins");
                    break;
                case 2:
                    Console.WriteLine("This machine does not take 2 cent coins");
                    break;
                case 3:
                    totalCoins = totalCoins + Coins[2].Value;
                    Console.WriteLine("Price Inserted: {0:cc}", totalCoins);
                    break;
                case 4:
                    totalCoins = totalCoins + Coins[3].Value;
                    Console.WriteLine("Price Inserted: {0:c}", totalCoins);
                    break;
                case 5:
                    totalCoins = totalCoins + Coins[4].Value;
                    Console.WriteLine("Price Inserted: {0:c}", totalCoins);
                    break;
                case 6:
                    totalCoins = totalCoins + Coins[5].Value;
                    Console.WriteLine("Price Inserted: {0:c}", totalCoins);
                    break;
                case 7:
                    totalCoins = totalCoins + Coins[6].Value;
                    Console.WriteLine("Price Inserted: {0:c}", totalCoins);
                    break;
                case 8:
                    totalCoins = totalCoins + Coins[7].Value;
                    Console.WriteLine("Price Inserted: {0:c}", totalCoins);
                    break;
                default:
                    break;
            }
        }

        if(totalCoins > coffeePrice)
        {
            double totalChange = totalCoins % coffeePrice;
            Console.WriteLine("Looks like you gave us more change than required, Here is your change: ");

            // while the totalChange is not 0, keep into this while loop 
            while(totalChange != 0)
            {
                // loop through the avaliable coins 
                foreach (var validCoins in Coins.Where(n => n.Accept == true).OrderByDescending(n => n.Value))
                {
                    // decrease the totalChange when any of the validCoin values is less the totalChange
                    if(validCoins.Value <= totalChange)
                    {
                        totalChange = Math.Round(totalChange - validCoins.Value, 2);
                        Console.WriteLine("$" + validCoins.Value.ToString("N"));
                    }
                }

                if (totalChange <= 0)
                {
                    break;
                }
            }
        }

        else if (totalCoins == coffeePrice)
        {
            Console.WriteLine("There is no changed needed for this trancation");
        }
    }


    /// <summary>
    /// List of instructions how to a Cappuccino, Latte and a Decaf, but isn't really neccassary for this task
    /// </summary>
    public async Task CappuccinoInstructions()
    {
        Console.WriteLine("\nStart making your Capuccino: ");
        await Task.Delay(500);
        Console.WriteLine("1. Foam and texture the required quantity of milk - Remember! We want more foam than steamed milk");
        await Task.Delay(500);
        Console.WriteLine("2. Brew a single or double espresso (as per taste or order) directly into your serving cup");
        await Task.Delay(500);
        Console.WriteLine("3. Gently swirl the milk to release any large air bubbles - tap the milk jug against a counter to remove any stubborn bubbles");
        await Task.Delay(500);
        Console.WriteLine("4. Pour the milk over the espresso from a low height for a smooth drink");
        await Task.Delay(500);
        Console.WriteLine("5. Finish by giving the milk a slight 'wiggle' to ensure foam transfers from milk jug to the cup to top off your Cappuccino");
        await Task.Delay(500);
        Console.WriteLine("6. Enjoy!!!");
        Environment.Exit(0);
    }

    public async Task LatteInstructions()
    {
        Console.WriteLine("\nStart making your Latte: ");
        await Task.Delay(500);
        Console.WriteLine("1. Prepare an espresso (single or double) directly into a latte glass");
        await Task.Delay(500);
        Console.WriteLine("2. 1/3 fill your milk jug");
        await Task.Delay(500);
        Console.WriteLine("3. Purge your steam arm prior to attempting to steam your milk");
        await Task.Delay(500);
        Console.WriteLine("4. Foam your milk prior to brewing your espresso, paying attention to creating a nice smooth microfoam");
        await Task.Delay(500);
        Console.WriteLine("5. After foaming/frothing your milk, gently tap the jug or bump on a table to remove any unwanted large air bubbles");
        await Task.Delay(500);
        Console.WriteLine("6. Begin pouring the frothed milk to your espresso from a relatively high position");
        await Task.Delay(500);
        Console.WriteLine("7. Continue to pour whilst lowering the milk and steepening your pouring angle");
        await Task.Delay(500);
        Console.WriteLine("8. Ensure a small amount of stiff milk foam sits on top after pouring");
        await Task.Delay(500);
        Console.WriteLine("9. Enjoy!!!");
        Environment.Exit(0);
    }

    public async Task DecafInstructions()
    {
        Console.WriteLine("\nStart making your Decaf: ");
        await Task.Delay(500);
        Console.WriteLine("1. Fill the water reservoir of your instant coffee machine with the desired amount of wate.");
        await Task.Delay(500);
        Console.WriteLine("2. Add a spoonful of decaf instant coffee to the filter basket. You can adjust the amount of coffee according to your personal taste.");
        await Task.Delay(500);
        Console.WriteLine("3. Place a mug under the filter basket.");
        await Task.Delay(500);
        Console.WriteLine("4. Turn on the coffee machine and allow the water to flow through the coffee and into the mug.");
        await Task.Delay(500);
        Console.WriteLine("5. Once the desired amount of coffee has been brewed, turn off the coffee machine and remove the mug.");
        await Task.Delay(500);
        Console.WriteLine("6. Add any desired cream, sugar, or other sweeteners to the coffee");
        await Task.Delay(500);
        Console.WriteLine("7. Enjoy!!!");
        Environment.Exit(0);
    }
}