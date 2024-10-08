﻿namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents the interface that needs to be implemented to view a game.  The viewport represents a coordinate system from 0, 0 to width - 1, height - 1.
/// </summary>
public interface IViewPort
{
    /// <summary>
    /// Returns the number of rows high for the viewport.  The implementing object needs to return a minimum value of 45.
    /// </summary>
    int Height { get; }

    /// <summary>
    /// Returns the number of columns wide for the viewport.  The implementing object needs to return a minimum value of 80.
    /// </summary>
    int Width { get; }

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
    /// Called when the in-game messages have been updated when a new message is appended to the log or when the count on the most-recent message is incremented.
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
    /// Called when the experience level for the player changes.
    /// </summary>
    /// <param name="level"></param>
    void ExperienceLevelChanged(int level);

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