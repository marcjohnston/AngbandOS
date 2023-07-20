namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents the "console" interface that needs to be implemented to play a game.
/// </summary>
public interface ISpectator
{
    /// <summary>
    /// Clear the entire screen.
    /// </summary>
    void Clear();

    /// <summary>
    /// Render output onto the screen.
    /// </summary>
    /// <param name="printLines"></param>
    void BatchPrint(PrintLine[] printLines);

    /// <summary>
    /// Set the background image.
    /// </summary>
    /// <param name="image"></param>
    void SetBackground(BackgroundImageEnum image);

    /// <summary>
    /// Play a sound.
    /// </summary>
    /// <param name="sound"></param>
    void PlaySound(SoundEffectEnum sound);

    /// <summary>
    /// Play music.
    /// </summary>
    /// <param name="music"></param>
    void PlayMusic(MusicTrackEnum music);

    /// <summary>
    /// Called when the in-game messages have been updated.
    /// </summary>
    void MessagesUpdated();
}