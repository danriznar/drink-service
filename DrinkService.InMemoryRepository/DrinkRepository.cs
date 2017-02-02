using DrinkService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkService.Core.Models;
using DrinkService.Core.Repositories;

namespace DrinkService.InMemoryRepository
{
    public class DrinkRepository : IDrinkRepository
    {
        private List<Drink> _drinkList = new List<Drink>
        {
            new Drink() { Id = "drink_1", Name = "Apple juice", Quantity = 1},
            new Drink() { Id = "drink_2", Name = "Grape juice", Quantity = 2},
            new Drink() { Id = "drink_3", Name = "Orange juice", Quantity = 3},
            new Drink() { Id = "drink_4", Name = "Pineapple juice", Quantity = 4}
        };

        public void Delete(string id)
        {
            _drinkList.RemoveAll(i => i.Id == id);
        }

        public Drink Get(string id)
        {
            return _drinkList.First(i => i.Id == id);
        }

        public IEnumerable<Drink> GetAll()
        {
            return _drinkList;
        }

        public Drink Create(Drink drink)
        {
            if(!_drinkList.Exists(i => i.Name == drink.Name))
            {
                if(_drinkList.Count != 0)
                {
                    var lastId = _drinkList.Last().Id;
                    var newId = Int32.Parse(lastId.Remove(0, 6)) + 1;
                    drink.Id = "drink_" + newId;
                    _drinkList.Add(drink);                    
                }
                else
                {
                    drink.Id = "drink_1";
                    _drinkList.Add(drink);
                }
                return drink;
            }
            else
            {
                throw new ArgumentException("Item already exists in the list.");
            }
        }

        public Drink Update(Drink drink)
        {
            if (_drinkList.Exists(i => i.Id == drink.Id))
            {
                var updateDrink = _drinkList.First(i => i.Id == drink.Id);
                updateDrink.Quantity = drink.Quantity;
                return updateDrink;
            }
            else
            {
                throw new ArgumentException("Item doesn't exists in the list.");
            }
        }
    }
}
