using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AreaDemo.Areas.Men.Models
{
    public class MenRepository
    {
        public List<MenClothing> GetCloths()
        {
            List<MenClothing> result = new List<MenClothing> { 
                new MenClothing () { Id = 1, Name = "Formal Shirt", Size= 40, Price = 1200, imageURL="/Areas/Men/Content/images/men_cloths/img_c1.jpg"},
                new MenClothing () { Id = 2, Name = "Jeans Pant", Size= 36, Price = 2200, imageURL="/Areas/Men/Content/images/men_cloths/img_c2.jpg"},
                new MenClothing () { Id = 3, Name = "Casual Shirt", Size= 40, Price = 1000, imageURL="/Areas/Men/Content/images/men_cloths/img_c3.jpg"},
                new MenClothing () { Id = 4, Name = "Formal Pant", Size= 36, Price = 1299, imageURL="/Areas/Men/Content/images/men_cloths/img_c4.jpg"}
            };

            return result;
        }

        public List<MenFootwears> GetFootwears()
        {
            List<MenFootwears> result = new List<MenFootwears> { 
                new MenFootwears () { Id = 1, Name = "Casual Slipper", Size= 8, Price = 1200, imageURL="/Areas/Men/Content/images/men_footwears/img_f1.jpg"},
                new MenFootwears () { Id = 2, Name = "Casual Slipper", Size= 9, Price = 2200, imageURL="/Areas/Men/Content/images/men_footwears/img_f2.jpg"},
                new MenFootwears () { Id = 3, Name = "Casual Shoes", Size= 9, Price = 2500, imageURL="/Areas/Men/Content/images/men_footwears/img_f3.jpg"},
                new MenFootwears () { Id = 4, Name = "Formal Shoes", Size= 9, Price = 1600, imageURL="/Areas/Men/Content/images/men_footwears/img_f4.jpg"}
            };

            return result;
        }
    }
}