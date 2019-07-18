
using Ego.Domain.Model;
using Ego.Domain.Repositories;
using Ego.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Service
{
    public class SqlDataService : Ego.Domain.Repositories.EntityFramework.RestaurantRepository, IDataService<Restaurant>
    {
        public SqlDataService(IRepositoryContext context) : base(context)
        {
        }

        public Restaurant GetItem()
        {
            return GetList().First();
        }

        public ICollection<Restaurant> GetList()
        {
            return this.GetList();
        }

        public void SaveInfo(Restaurant model)
        {
            Save(model);
            Context.Commit();

            //using (var ctx = new MVVMRepository())
            //{

            //    if (model.ID == null)
            //    {
            //        //model.PKID = Guid.NewGuid().ToString();
            //        ctx.Insert(model);
            //    }
            //    else
            //    {
            //        //Restaurant tempRes = (from a in ctx.Restaurants
            //        //                      where a.PKID == model.PKID
            //        //                      select a).First();

            //        //tempRes.Name = model.Name;
            //        //tempRes.PhoneNumber = model.PhoneNumber;
            //        //tempRes.Address = model.Address;
            //        ctx.Update(model);
            //    }

            //    foreach (Dish item in model.Dishes)
            //    {
            //        if (item.ID == null)
            //        {
            //            //item.PKID = Guid.NewGuid().ToString();
            //            //ctx.Dishes.Add(item);
            //            ctx.Insert(item);
            //        }
            //        else
            //        {
            //            //Dish tempDish = (from a in ctx.Dishes
            //            //                 where a.PKID == item.PKID
            //            //                 select a).First();

            //            //tempDish.Category = item.Category;
            //            //tempDish.Comment = item.Comment;
            //            //tempDish.Name = item.Name;
            //            //tempDish.Score = item.Score;
            //            //tempDish.FKID_Restaurant = model.PKID;
            //            ctx.Update(item);
            //        }
            //    }

            //    ctx.Commit();
            //}
        }
    }
}
