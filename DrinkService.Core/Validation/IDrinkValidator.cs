using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkService.Core.Models;
using DrinkService.Core.Validation.Entities;

namespace DrinkService.Core.Validation
{
    public interface IDrinkValidator
    {
        ValidationResult Validate(Drink drink);
    }
}
