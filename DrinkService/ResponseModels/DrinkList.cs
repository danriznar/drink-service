using DrinkService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkService.ResponseModels
{
    public class DrinkList
    {
        public int Count { get; set; }
        public List<Drink> Data { get; set; }
    }
}