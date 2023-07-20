namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents the "console" interface that needs to be implemented to play a game.
/// </summary>
public interface IConsole : ISpectator
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
    /// Retrieve a keypress from the user.
    /// </summary>
    /// <returns></returns>
    char WaitForKey();

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

    bool KeyQueueIsEmpty();

    /// <summary>
    /// Called when the in-game messages have been updated.
    /// </summary>
    void MessagesUpdated();

    /// <summary>
    /// Called when the player dies.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="diedFrom"></param>
    /// <param name="level"></param>
    void PlayerDied(string name, string diedFrom, int level);

    /// <summary>
    /// Called when the players' gold level changes.
    /// </summary>
    /// <param name="gold"></param>
    void GoldUpdated(int gold);

    /// <summary>
    /// Called when the players' characters' name changes.
    /// </summary>
    /// <param name="name"></param>
    void CharacterRenamed(string name);

    /// <summary>
    /// Called when the level that the player is on changes.
    /// </summary>
    /// <param name="level"></param>
    void LevelChanged(int level);

    /// <summary>
    /// Called when the game starts.
    /// </summary>
    void GameStarted();

    /// <summary>
    /// Called when the game stops.
    /// </summary>
    void GameStopped();

    /// <summary>
    /// Called when an unexpected exception is thrown during the game.
    /// </summary>
    /// <param name="message"></param>
    void GameExceptionThrown(string message);

    /// <summary>
    /// Called when the game time changes.
    /// </summary>
    void GameTimeElapsed();

    /// <summary>
    /// Called when input is received from the player.
    /// </summary>
    void InputReceived();
}