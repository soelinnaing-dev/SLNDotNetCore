using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNDotNetCore.MiniPizzaOrderSystem
{
    internal class Data
    {
        internal List<Pizza> pizzas = new List<Pizza>()
        {
            new Pizza() { Id=1, pizzaName= "Margherita", pizzaPrice= 8.99 },
            new Pizza() { Id=2, pizzaName= "Pepperoni", pizzaPrice= 9.99 },
            new Pizza() { Id=3, pizzaName= "Vegetarian", pizzaPrice= 10.99 },
            new Pizza() { Id=3, pizzaName= "Hawaiian", pizzaPrice= 11.99 },
        };

        internal List<Extra> extras = new List<Extra>()
        {
            new Extra() { Id=1,extraName = "Cheese",extraPrice = 1.0},
            new Extra() { Id=2,extraName = "Mushrooms",extraPrice=2.0},
            new Extra() { Id=3,extraName = "Onions",extraPrice = 3.0},
            new Extra() { Id=4,extraName = "Peppers",extraPrice = 4.0}
        };

        internal static bool isAddExtra { get; set; }
        internal static Pizza pizzaInfo { get; set; }
        internal static Extra extraInfo { get; set; }

        private static double getTotalPrice (Pizza pizza,Extra extra)
        {          
            if(isAddExtra)
            {
                pizza.pizzaName = pizzaInfo.pizzaName;
                pizza.pizzaPrice = pizzaInfo.pizzaPrice;
                extra.extraName = extraInfo.extraName;
                extra.extraPrice = extraInfo.extraPrice;               
            }
            return default;
        }
    }
    
}
