using System.Threading.Tasks;

namespace Actio.Common.Event {
    public interface IEventHandler<in T> where T : IEvents {
        Task HandleAsync (T command);
    }
}