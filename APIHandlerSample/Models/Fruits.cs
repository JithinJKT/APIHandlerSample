using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHandlerSample.Models
{
    public class DailyFruitParam
    {
        public int CustomerID { get; set; }
    }

    public class DailyFruit
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Caption { get; set; }

    }
}