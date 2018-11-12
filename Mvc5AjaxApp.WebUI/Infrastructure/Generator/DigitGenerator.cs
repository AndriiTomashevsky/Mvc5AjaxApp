using Mvc5AjaxApp.Domain.Entities;
using Mvc5AjaxApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Mvc5AjaxApp.WebUI.Infrastructure.Generator
{
    public class DigitGenerator : IDigitGenerator
    {
        IDigitCreator digitCreator;
        HashSet<Digit> hashSet;

        public DigitGenerator(IDigitCreator creator, HashSet<Digit> hashSet)
        {
            digitCreator = creator;
            this.hashSet = hashSet;
        }

        public ICollection<Digit> GenerateDigits(ICollection<Digit> digits, int? n)
        {
            if (digits != null)
            {
                hashSet = digits as HashSet<Digit>;
            }

            for (int i = 0; i < n; i++)
            {
                CreateUniqueDigit();
            }

            return hashSet;
        }

        private Digit CreateUniqueDigit()
        {
            Digit digit = digitCreator.CreateDigit();

            while (!hashSet.Add(digit))
            {
                digit = digitCreator.CreateDigit();
            }

            return digit;
        }
    }
}