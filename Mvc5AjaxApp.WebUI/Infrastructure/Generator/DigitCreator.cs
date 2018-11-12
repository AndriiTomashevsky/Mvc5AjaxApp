using Mvc5AjaxApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Mvc5AjaxApp.WebUI.Infrastructure.Generator
{
    public class DigitCreator : IDigitCreator
    {
        Random random=new Random();

        public Digit CreateDigit()
        {
            StringBuilder builder = new StringBuilder();

            while (builder.Length < 16)
            {
                builder.Append(random.Next(10).ToString());
            }

            Digit digit = new Digit() { Number = builder.ToString() };

            return digit;
        }

    }

    public interface IDigitCreator
    {
        Digit CreateDigit();
    }
}