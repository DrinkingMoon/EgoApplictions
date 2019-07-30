using Ego.Domain.Model;

namespace Ego.Domain.Events.Interface
{
    public interface IUserEvent
    {
        void Save(User user);
    }
}