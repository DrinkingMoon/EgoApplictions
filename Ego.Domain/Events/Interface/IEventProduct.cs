using Ego.Domain.Model;

namespace Ego.Domain.Events.Interface
{
    public interface IEventProduct
    {
        void Save(Product product);
    }
}