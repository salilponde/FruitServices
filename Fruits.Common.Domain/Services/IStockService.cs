using System;
using System.Collections.Generic;
using System.Text;

namespace Fruits.Common.Domain.Services
{
    public interface IStockService
    {
        int GetStock();

        void Buy(int count);

        void Sell(int count);
    }
}
