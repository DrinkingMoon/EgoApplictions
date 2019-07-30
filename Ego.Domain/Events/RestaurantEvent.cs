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

namespace Ego.Domain.Events
{
    public class RestaurantEvent : IRestaurantEvent
    {
        IContext _context;

        IRestaurantRepository _rep_Restaurant;

        public RestaurantEvent(IContext context, IRestaurantRepository repRestaurant)
        {
            _context = context;
            _rep_Restaurant = repRestaurant;
        }

        public void Save(Restaurant restaurant)
        {
            Restaurant tempInfo = _rep_Restaurant.GetItem(restaurant.ID);

            if (tempInfo == null)
            {
                _rep_Restaurant.Insert(restaurant);
            }
            else
            {
                _rep_Restaurant.Update(restaurant);
            }

            _context.Commit();
        }
    }
}
