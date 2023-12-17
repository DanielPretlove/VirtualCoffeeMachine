using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualCoffeeMachine.Models.Coins;

namespace VirtualCoffeeMachine.Helpers
{
    public class CoinHelper
    {
        public static List<CoinModel> CreateCoins()
        {
            return new List<CoinModel> 
            { 
                new CoinModel { Id = 1, Type = CoinTypeEnum.Cents, Coins = 1, Value = 0.01, Accept = false }, 
                new CoinModel { Id = 2, Type = CoinTypeEnum.Cents, Coins = 2, Value = 0.02, Accept = false }, 
                new CoinModel { Id = 3, Type = CoinTypeEnum.Cents, Coins = 5, Value = 0.05, Accept = true },
                new CoinModel { Id = 4, Type = CoinTypeEnum.Cents, Coins = 10, Value = 0.10, Accept = true },
                new CoinModel { Id = 5, Type = CoinTypeEnum.Cents, Coins = 20, Value = 0.20, Accept = true },
                new CoinModel { Id = 6, Type = CoinTypeEnum.Cents, Coins = 50, Value = 0.50, Accept = true },
                new CoinModel { Id = 7, Type = CoinTypeEnum.Dollars, Coins = 1, Value = 1.00, Accept = true },
                new CoinModel { Id = 8, Type = CoinTypeEnum.Dollars, Coins = 2, Value = 2.00, Accept = true },
            };
        }
    }
}
