using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AreaDemo.Areas.Men.Models
{
    public class MenClothing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
        public string imageURL { get; set; }
    }
}