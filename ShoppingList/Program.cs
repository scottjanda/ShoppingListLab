
using System.Linq;

Dictionary<string, decimal> menu = new();

menu.Add("apples", 2.50m);
menu.Add("beef", 7.00m);
menu.Add("candy", 1.25m);
menu.Add("dill pickles", 3.75m);
menu.Add("eggs", 5.50m);
menu.Add("fajitas", 1.75m);
menu.Add("grapes", 2.75m);
menu.Add("ham", 4.75m);

List<string> listMenu = menu.Keys.ToList();
List<string> shoppingList = new();
List<decimal> listValues = new();

Console.WriteLine("Welcome to Chirpus Market!");

string userContinue = "y";

do
{
    bool validInput = false;
    Console.WriteLine();
    Console.WriteLine("{0,-10} {1,-15} {2,0}", "Number", "Item", "Price");
    Console.WriteLine("==============================");
    int counter = 0;

    foreach (var item in menu)
    {
        Console.WriteLine($"{listMenu.IndexOf(item.Key) + 1,-10} {item.Key,-15} ${item.Value,0}");
        counter += 1;
    }

    Console.Write("\nWhat item would you like to order? Enter the name of the item or the coresponding number: ");
    string addItem = Console.ReadLine();

    foreach (var item in menu)
    {
        int.TryParse(addItem, out int intAddItem);
        if (addItem.ToLower().Equals(item.Key) || intAddItem == listMenu.IndexOf(item.Key) + 1)
        {
            shoppingList.Add(item.Key);
            Console.WriteLine($"\nAdding {item.Key} to the cart at ${item.Value}\n");
            validInput = true;
        }
    }

    if (validInput == false)
    {
        Console.WriteLine("\nSorry, we don't have those.  Please try again.\n");
        continue;
    }

    Console.Write("Would you like to order anything else (y/n)? ");
    userContinue = Console.ReadLine();

} while (userContinue.ToLower() == "y");

Console.WriteLine("\nThanks for your order!");
Console.WriteLine("Here's what you got:\n");

foreach (var item in shoppingList)
{
    listValues.Add(menu[item]);
    Console.WriteLine($"{item,-15} ${menu[item],0}");
}

Console.WriteLine($"\nthe most expensive item ordered is ${listValues.Max()}.");
Console.WriteLine($"\nthe least expensive item ordered is ${listValues.Min()}.");
Console.WriteLine($"\nthe average price of all items ordered is ${Math.Round(listValues.Average(), 2)}.");





