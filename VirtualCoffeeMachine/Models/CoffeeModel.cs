using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualCoffeeMachine.Models
{
    public class CoffeeModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public required string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}: ${Price.ToString("N")} {Name}";
        }
    }
}
