﻿using AngbandOS.Core.Interface;
namespace AngbandOS.Web.Hubs;

/// <summary>
/// Represents an interface that defines the outgoing signal-r methods that the a spectating client can receive.  There is no WaitForKey or inputs from a spectating client.
/// used for playing games.
/// </summary>
public interface ISpectatingHub
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
