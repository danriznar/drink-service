using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkService.Core.Models;
using DrinkService.Core.Validation.Entities;

namespace DrinkService.Core.Validation
{
    public class DrinkValidator : IDrinkValidator
    {
        public ValidationResult Validate(Drink drink)
        {
            var isValid = true;
            var errorList = new List<string>();

            if(drink == null)
            {
                isValid = false;
                errorList.Add("Drink object is null");
            }
            else
            {
                if (String.IsNullOrEmpty(drink.Name))
                {
                    isValid = false;
                    errorList.Add("Drink name empty");
                }
                if (drink.Quantity <= 0)
                {
                    isValid = false;
                    errorList.Add("Drink quantity non-positive");
                }
            }

            return new ValidationResult(isValid, errorList);
        }
    }
}
