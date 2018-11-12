using Mvc5AjaxApp.Domain.Entities;
using System.Collections.Generic;

namespace Mvc5AjaxApp.WebUI.Infrastructure.Generator
{
    public interface IDigitGenerator
    {
        ICollection<Digit> GenerateDigits(ICollection<Digit> digits, int? n);
    }
}
