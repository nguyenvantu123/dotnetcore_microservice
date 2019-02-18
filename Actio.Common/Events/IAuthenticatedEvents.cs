using System;

namespace Actio.Common.Event {
    public interface IAuthenticatedEvents : IEvents {
        Guid UserId { get; set; }
    }
}