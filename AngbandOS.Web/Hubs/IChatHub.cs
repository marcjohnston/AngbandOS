using AngbandOS.Web.Models;
namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents an interface that defines the outgoing methods that the service can send to a client through the Signal-R connection.
    /// </summary>
    public interface IChatHub
    {
        /// <summary>
        /// Informs the client that a SendMessage call failed.
        /// </summary>
        /// <returns></returns>
        Task MessageFailed();

        /// <summary>
        /// Outgoing message to a web client that the chat history has changed.  This signature must be identical to the same method on the IServiceHub.
        /// </summary>
        /// <returns></returns>
        Task ChatRefreshed(ChatMessage[] history);

        Task ChatUpdated(ChatMessage message);
    }
}
