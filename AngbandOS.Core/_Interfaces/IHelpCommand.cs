﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents the interface for a command that can be rendered on a help screen.
/// </summary>
internal interface IHelpCommand
{
    /// <summary>
    /// Represents the keystroke for the player to press to be activate the command.
    /// </summary>
    char KeyChar { get; }

    /// <summary>
    /// Represents whether or not the command is available.  If the command isn't available, it won't be rendered on the help screen.
    /// </summary>
    bool IsEnabled => true;

    /// <summary>
    /// Represents the name of a group of commands that thecommand should be rendered with on the help screen.  If null, the command will not be rendered.
    /// </summary>
    HelpGroup? HelpGroup { get; }

    /// <summary>
    /// Represents a description to be rendered with the command for the player to understand what the command does.
    /// </summary>
    string HelpDescription { get; }
}
