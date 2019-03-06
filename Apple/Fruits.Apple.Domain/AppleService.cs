using Fruits.Common.Domain.Services;
using System;

namespace Fruits.Apple.Domain
{
    public class AppleService : IStockService
    {
        private static int _count = 0;

        public int GetStock()
        {
            return _count;
        }

        public void Buy(int count)
        {
            _count += count;
        }

        public void Sell(int count)
        {
            _count -= count;
        }
    }
}
