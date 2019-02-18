namespace Actio.Common.Event {
    public interface IRejectedEvent : IEvents {
        string Reason { get;} 

        string Code { get;}
    }
}