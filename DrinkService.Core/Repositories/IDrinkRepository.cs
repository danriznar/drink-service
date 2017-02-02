using DrinkService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkService.Core.Repositories
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> GetAll();
        Drink Get(string id);
        Drink Create(Drink drink);
        Drink Update(Drink drink);
        void Delete(string id);
    }
}
