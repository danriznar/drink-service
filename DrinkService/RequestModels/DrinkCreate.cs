using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkService.RequestModels
{
    public class DrinkCreate
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}