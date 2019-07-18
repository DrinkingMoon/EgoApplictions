using Ego.Domain.Model;
using Ego.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ego.Service
{
    public class XmlDataService : IDataService<Restaurant>
    {
        public Restaurant GetItem()
        {
            List<Dish> lstDish = new List<Dish>();

            XDocument xd = XDocument.Load(System.IO.Path.Combine(Environment.CurrentDirectory, "Data.xml"));

            foreach (var d in xd.Descendants("Dish"))
            {
                Dish dish = new Dish();
                dish.Name = d.Element("Name").Value;
                dish.Category = d.Element("Category").Value;
                dish.Comment = d.Element("Comment").Value;
                dish.Score = double.Parse(d.Element("Score").Value);
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
            ICollection<Restaurant> result = new List<Restaurant>();
            result.Add(GetItem());

            return result;
        }

        public void SaveInfo(Restaurant model)
        {
            System.IO.File.WriteAllLines(@"Order.txt", model.Dishes.Select(k=> k.Name).ToList());
        }
    }
}
