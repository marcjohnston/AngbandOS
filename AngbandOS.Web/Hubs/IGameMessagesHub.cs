using AngbandOS.Core.Interface;

namespace AngbandOS.Web.Hubs;

/// <summary>
/// Represents an interface that defines the outgoing signal-r methods that the game can send.  This interface is
/// used for playing games.
/// </summary>
public interface IGameMessagesHub
{
    /// <summary>
    /// Outgoing message to a web client that the game is over.
    /// </summary>
    /// <returns></returns>
    Task GameOver();

    /// <summary>
    /// Outgoing message to a web client with the requested game messages.
    /// </summary>
    /// <returns></returns>
    Task GameMessagesReceived(PageOfGameMessages? pageOfGameMessages);
}
