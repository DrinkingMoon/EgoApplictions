using Ego.Domain.Model;

namespace Ego.Domain.Events.Interface
{
    public interface IEventUser
    {
        void Save(User user);
    }
}