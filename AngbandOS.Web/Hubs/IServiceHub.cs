using AngbandOS.Web.Models;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents an interface that defines the outgoing methods that the service can send through the Signal-R connection.
    /// </summary>
    public interface IServiceHub
    {
        /// <summary>
        /// Outgoing message to a web client that the active games list has changed.
        /// </summary>
        /// <returns></returns>
        Task ActiveGamesUpdated(ActiveGameDetails[] activeGames);
    }
}
