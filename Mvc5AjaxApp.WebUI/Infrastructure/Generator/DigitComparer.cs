using Mvc5AjaxApp.Domain.Entities;
using System.Collections.Generic;

namespace Mvc5AjaxApp.WebUI.Infrastructure
{
    public class DigitComparer : IEqualityComparer<Digit>
    {
        public DigitComparer()
        {
        }

        public bool Equals(Digit x, Digit y)
        {
            return x.Number.Equals(y.Number);
        }

        public int GetHashCode(Digit obj)
        {
            return obj.Number.GetHashCode();
        }
    }
}