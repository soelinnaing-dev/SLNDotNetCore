using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNDotNetCore.MiniPizzaOrderSystem
{    
    internal class Pizza
    {
        public int Id { get; set; }
        public string pizzaName { get; set; }
        public double pizzaPrice { get; set; }
    }

    internal class Extra
    {
        public int Id { get; set; }
        public string extraName { get; set; }
        public double extraPrice { get; set; }
    }
}
