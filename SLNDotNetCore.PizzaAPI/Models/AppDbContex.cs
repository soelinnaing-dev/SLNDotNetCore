using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLNDotNetCore.PizzaAPI.ConnectionStrings;

namespace SLNDotNetCore.PizzaAPI.Models
{
    internal class AppDbContex : DbContext
    {
        //ConnectoinStrings connectoinStrings = new ConnectoinStrings();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectoinStrings._constringbuilder.ConnectionString);
        }

        public DbSet<Pizza> Pizzas { get; set; }

        public  DbSet<Extra>Extras { get; set; }

        public DbSet<PizzaOrder> PizzasOrder { get; set; }

        public DbSet<PizzaOrderDetails> PizzasOrderDetails { get; set; }
        //public object PizzaModel { get; internal set; }
        //public object ExtraModel { get; internal set; }
    }
}
