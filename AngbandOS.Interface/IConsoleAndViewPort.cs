namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents the interface that needs to be implemented to play a game.  It also requires that console to be a viewport.
/// </summary>
public interface IConsoleAndViewPort : IViewPort
{
    /// <summary>
    /// Retrieve a keypress from the user.
    /// </summary>
    /// <returns></returns>
    char? GetKey();

    /// <summary>
    /// Messages from the previous command have been received.
    /// </summary>
    /// <param name="gameMessages"></param>
    /// <exception cref="NotImplementedException"></exception>
    void MessagesReceived(IGameMessage[] gameMessages);
}