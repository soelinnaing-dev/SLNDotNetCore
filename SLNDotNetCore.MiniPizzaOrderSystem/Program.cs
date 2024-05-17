using System;
using System.Collections.Generic;
using System.Linq;
using SLNDotNetCore.MiniPizzaOrderSystem;

namespace MiniPizzaOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Choose Pizza");
            Console.WriteLine("===================\r\n");
            Data data = new Data();

            if (data.pizzas.Count <= 0)
            {
                Console.WriteLine("Unavailable Now!");
                return;
            }

            int chosenPizzaIndex;
            while (true)
            {
                for (int i = 0; i < data.pizzas.Count; i++)
                {
                    var item = data.pizzas[i];
                    Console.WriteLine($"{i + 1}. {item.pizzaName,-20}{item.pizzaPrice.ToString("C")}");
                }

                Console.WriteLine("Please Select Pizza By Pressing Number:");
                string input = Console.ReadLine()!;
                if (!int.TryParse(input, out chosenPizzaIndex) || chosenPizzaIndex < 1 || chosenPizzaIndex > data.pizzas.Count)
                {
                    Console.WriteLine("Invalid selection. Please choose a number from the list.");
                    continue;
                }
                break;
            }

            Pizza selectedPizza = data.pizzas[chosenPizzaIndex - 1];

            Console.WriteLine("Do you want to add extras? (Y/N)");
            string addExtra = Console.ReadLine().Trim().ToUpper();

            List<Extra> selectedExtras = new List<Extra>();
            if (addExtra == "Y")
            {
                Data.isAddExtra = true;
                while (true)
                {
                    Console.WriteLine("Available Extras:");
                    for (int i = 0; i < data.extras.Count; i++)
                    {
                        var extra = data.extras[i];
                        Console.WriteLine($"{i + 1}. {extra.extraName,-20}{extra.extraPrice.ToString("C")}");
                    }

                    Console.WriteLine("Please Select Extras By Pressing Numbers Separated By Commas (Press Enter to finish):");
                    string extraInput = Console.ReadLine()!;
                    if (string.IsNullOrWhiteSpace(extraInput))
                    {
                        break;
                    }

                    var selectedIndices = extraInput.Split(',')
                        .Select(s => s.Trim())
                        .Where(s => int.TryParse(s, out int _))
                        .Select(int.Parse)
                        .ToList();

                    if (selectedIndices.Any(idx => idx < 1 || idx > data.extras.Count))
                    {
                        Console.WriteLine("Invalid selection. Please choose numbers from the list.");
                        continue;
                    }

                    foreach (var index in selectedIndices.Distinct())
                    {
                        Extra selectedExtra = data.extras[index - 1];
                        if (!selectedExtras.Contains(selectedExtra))
                        {
                            selectedExtras.Add(selectedExtra);
                            Console.WriteLine($"{selectedExtra.extraName} added.");
                        }
                    }
                    break;
                }
            }
            double totalPrice = data.getTotalPrice(selectedPizza, selectedExtras.ToArray());
            Console.WriteLine($"\nTotal price for {selectedPizza.pizzaName} with selected extras: {totalPrice.ToString("C")}");
        }
    }
}
