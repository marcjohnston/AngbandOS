using AngbandOS.Core.Interface;

namespace AngbandOS.Web.Hubs;

/// <summary>
/// Represents an interface that defines the outgoing signal-r methods that the game can send.  This interface is
/// used for playing games.
/// </summary>
public interface ISpectatorsHub
{
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
    Task Print(int row, int col, string text, Colour foreColor, Colour backColour);

    /// <summary>
    /// Outgoing message to a web client to set a background image.
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    Task SetBackground(BackgroundImage image);

    /// <summary>
    /// Outgoing message to a web client to play a sound.
    /// </summary>
    /// <param name="sound"></param>
    /// <returns></returns>
    Task PlaySound(SoundEffect sound);

    /// <summary>
    /// Outgoing message to a web client to play a music track.
    /// </summary>
    /// <param name="music"></param>
    /// <returns></returns>
    Task PlayMusic(MusicTrack music);
}
