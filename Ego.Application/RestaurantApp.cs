using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Ego.Domain;
using Ego.Domain.Model;
using Ego.Domain.Repositories;
using Ego.Domain.Service;
using Ego.Domain.Events;
using Ego.Domain.Events.Interface;

namespace Ego.Application
{
    public class RestaurantApp
    {
        static IContext _context = RepositoryFactory.EFDbContextEgo();
        static IRestaurantRepository _rep_Restaurant = RepositoryFactory.Repository<Restaurant, IRestaurantRepository>();
        IRestaurantEvent _event_Restaurant = new RestaurantEvent(_context, _rep_Restaurant);

        public RestaurantApp()
        {

        }

        public void Save(Restaurant rest)
        {
            _event_Restaurant.Save(rest);
        }

        public Restaurant GetItem()
        {
            Restaurant restaurant = _rep_Restaurant.GetItem();

            if (restaurant == null)
            {
                return new Restaurant().CreateNew();
            }
            else
            {
                return restaurant;
            }
        }
    }
}
