using Ego.Domain.Model;

namespace Ego.Domain.Events.Interface
{
    public interface IProductEvent
    {
        void Save(Product product);
    }
}