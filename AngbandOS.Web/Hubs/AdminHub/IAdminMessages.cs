namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents an interface that defines the outgoing methods that the service can send to a client through the Signal-R connection.
    /// </summary>
    public interface IAdminMessages
    {
        Task HubConnectionsUpdated(HubConnections hubConnections);
    }
}
