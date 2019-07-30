using Ego.Domain.Model;

namespace Ego.Domain.Events.Interface
{
    public interface IRestaurantEvent
    {
        void Save(Restaurant restaurant);
    }
}