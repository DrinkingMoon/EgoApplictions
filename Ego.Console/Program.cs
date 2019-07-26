using Ego.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Model;

namespace Ego.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageApp storageApp = new StorageApp();
            storageApp.Save(new Storage() { Name = "原材料库房" });

            ProductApp productApp = new ProductApp();
            productApp.Save(new Product() { Code = "P1", Name = "肥皂", Spec = "日式" , Producttype = "1日1用1品1" });

            UserApp userApp = new UserApp();
            userApp.Save(new User() { Name = "张三", Age = 28, Department = "车间", WorkID = "0001" });
        }
    }
}
