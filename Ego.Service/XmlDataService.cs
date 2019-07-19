using Ego.Domain.Model;
using Ego.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ego.Domain.Service
{
    public class XmlDataService : IDataService<Restaurant>
    {
        public Restaurant GetItem()
        {
            List<Dish> lstDish = new List<Dish>();

            XDocument xd = XDocument.Load(System.IO.Path.Combine(Environment.CurrentDirectory, "Data.xml"));

            foreach (var d in xd.Descendants("Dish"))
            {
                Dish dish = new Dish
                {
                    Name = d.Element("Name").Value,
                    Category = d.Element("Category").Value,
                    Comment = d.Element("Comment").Value,
                    Score = double.Parse(d.Element("Score").Value)
                };
                //添加到List集合
                lstDish.Add(dish);
            }

            Restaurant result = new Restaurant()
            {
                Name = "味尚餐厅",
                Address = "岳麓区金星大道108号",
                PhoneNumber = "15874865582",
                Dishes = lstDish
            };

            return result;
        }

        public ICollection<Restaurant> GetList()
        {
            ICollection<Restaurant> result = new List<Restaurant>
            {
                GetItem()
            };

            return result;
        }

        public void SaveInfo(Restaurant model)
        {
            System.IO.File.WriteAllLines(@"Order.txt", model.Dishes.Select(k=> k.Name).ToList());
        }
    }
}
