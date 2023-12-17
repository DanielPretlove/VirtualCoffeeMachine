using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualCoffeeMachine.Models;

namespace VirtualCoffeeMachine.Helpers
{
    public class CoffeeHelper
    {
        public static List<CoffeeModel> CreateCoffees()
        {
            return new List<CoffeeModel>()
            {
                new CoffeeModel { Id = 1, Name = "Cappuccino", Price = 3.50 },
                new CoffeeModel { Id = 2, Name = "Latte", Price = 3.00 },
                new CoffeeModel { Id = 3, Name = "Decaf", Price = 4.00 }
            };
        }
    }
}
