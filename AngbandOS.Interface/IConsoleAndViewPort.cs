namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents the interface that needs to be implemented to play a game.  It also requires that console to be a viewport.
/// </summary>
public interface IConsoleAndViewPort : IViewPort
{
    /// <summary>
    /// Returns the maximum length of the queue used to store keystrokes.  The implementing object must return a value >= 1.  256 is recommended.
    /// </summary>
    int MaximumKeyQueueLength { get; }

    /// <summary>
    /// Retrieve a keypress from the user.
    /// </summary>
    /// <returns></returns>
    char WaitForKey();

    bool KeyQueueIsEmpty();

    /// <summary>
    /// Messages from the previous command have been received.
    /// </summary>
    /// <param name="gameMessages"></param>
    /// <exception cref="NotImplementedException"></exception>
    void MessagesReceived(IGameMessage[] gameMessages);
}