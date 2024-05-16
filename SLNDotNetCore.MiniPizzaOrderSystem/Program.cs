using SLNDotNetCore.MiniPizzaOrderSystem;
using System.Threading.Channels;
Console.WriteLine("Please Choose Pizza");
Console.WriteLine("===================\r\n");
Data data = new Data();
if (data.pizzas.Count <= 0)
{ Console.WriteLine("Unavailabe Now!"); return; };
while (true)
{
    foreach (var item in data.pizzas)
    {
        Console.WriteLine($"{item.pizzaName,-20}{item.pizzaPrice.ToString("C")}");
    }
    int choose;
    Console.WriteLine("Please Select Pizzia By Pressing Number:");
    string input = Console.ReadLine()!;
    if (!int.TryParse(input, out choose))
    {
        Console.WriteLine("Invalid input, please try again!");
        continue;
    }
    if (choose < 1 || choose > data.pizzas.Count)
    {
        Console.WriteLine("Invalid selection. Please choose a number from the list.");
        continue;
    }
    break;
}
Console.WriteLine("Do you want add extra?(Y/N)");
string addExtra = Console.ReadLine().Trim().ToUpper();
if(addExtra =="Y")
{

}