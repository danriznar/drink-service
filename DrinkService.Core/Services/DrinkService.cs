using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkService.Core.Models;
using DrinkService.Core.Repositories;

namespace DrinkService.Core.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository _repository;

        public DrinkService(IDrinkRepository repository)
        {
            this._repository = repository;
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public Drink Get(string id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Drink> GetAll()
        {
            return _repository.GetAll();
        }

        public Drink Create(Drink drink)
        {
            return _repository.Create(drink);
        }

        public Drink Update(Drink drink)
        {
            return _repository.Update(drink);
        }
    }
}
