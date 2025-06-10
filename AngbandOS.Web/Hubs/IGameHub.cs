using AngbandOS.Core.Interface;
namespace AngbandOS.Web.Hubs;

/// <summary>
/// Represents an interface that defines the outgoing signal-r methods that the game can send.  This interface is
/// just used for playing games--not spectating games.
/// </summary>
public interface IGameHub
{
    /// <summary>
    /// Sends a generic message to the client.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    Task SendMessage(string message);

    /// <summary>
    /// Sends a message to the client that the game cannot be played because it is incompatible.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    Task GameIncompatible();

    /// <summary>
    /// Outgoing message to the client that the game started.  The primary purpose for this message is for the client
    /// to be able to receive the guid for a new game that was created.
    /// </summary>
    /// <returns></returns>
    Task GameStarted(string guid);

    /// <summary>
    /// Outgoing message to a web client that the game is over.
    /// </summary>
    /// <returns></returns>
    Task GameOver();

    /// <summary>
    /// Outgoing message to a web client to clear the screen.
    /// </summary>
    /// <returns></returns>
    Task Clear();

    /// <summary>
    /// Outgoing message to a web client to print text at a specific screen position and in a specific color.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="text"></param>
    /// <param name="colour"></param>
    /// <returns></returns>
    Task BatchPrint(PrintLine[] printLines);

    /// <summary>
    /// Outgoing message to a web client to set a background image.
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    Task SetBackground(BackgroundImageEnum image);

    /// <summary>
    /// Outgoing message to a web client to play a sound.
    /// </summary>
    /// <param name="sound"></param>
    /// <returns></returns>
    Task PlaySound(SoundEffectEnum sound);

    /// <summary>
    /// Outgoing message to a web client to play a music track.
    /// </summary>
    /// <param name="music"></param>
    /// <returns></returns>
    Task PlayMusic(MusicTrackEnum music);
}
