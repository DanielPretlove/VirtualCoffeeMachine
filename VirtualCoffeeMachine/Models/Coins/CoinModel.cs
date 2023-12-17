using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualCoffeeMachine.Models.Coins
{
    public class CoinModel
    {
        public int Id { get; set; }
        public int Coins { get; set; }
        public double Value { get; set; }
        public CoinTypeEnum Type { get; set; }
        public bool Accept { get; set; }
    }
}
