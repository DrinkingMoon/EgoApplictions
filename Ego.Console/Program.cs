using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Model;
using Ego.Domain.Service;
using Ego.Domain.Service.Interface;

namespace Ego.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Restaurant> ds = new SqlDataService(); 
            Restaurant res = ds.GetItem();
            //res.Dishes.Add(new Dish() {
            //    Name = "炒粉",
            //    Category = "炒粉",
            //    Comment = "",
            //    Score = 1
            //});

            ds.SaveInfo(res);

            //rp.Add(new Restaurant()
            //{
            //    Name = "味尚餐厅",
            //    Address = "岳麓区金星大道108号",
            //    PhoneNumber = "15874865582"
            //});

            //Guid guid = Guid.Parse("5DE8198A-D1A9-E911-9576-408D5C2F602D");
            //rp.Remove(rp.GetItem(k => k.ID == guid));

            //Restaurant restaurant = rp.GetItem(k => k.Name == "味尚餐厅");
            //restaurant.PhoneNumber = "3333333333";
            //rp.Save(rp.GetItem(k => k.Name == "味尚餐厅"));

            //Console.ReadKey();
        }
    }
}
