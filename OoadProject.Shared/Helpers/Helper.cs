using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Shared.Helpers
{
    public static class Helper
    {
        public static int CalculatePriceout(int priceIn, float returnRate)
        {
            return (int)Math.Round(priceIn * (1 + returnRate / 100) / 1000) * 1000;
        }
    }
}
