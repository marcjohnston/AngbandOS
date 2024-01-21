// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Repeat the level feeling for the player and also say where we are
/// </summary>
[Serializable]
internal class FeelingAndLocationCommand : GameCommand
{
    private FeelingAndLocationCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char KeyChar => 'H';

    protected override string ExecuteScriptName => nameof(SayLocationAndFeelingScript);
}
