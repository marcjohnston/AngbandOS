// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Aim a wand from your inventory
/// </summary>
/// <param name="itemIndex"> The inventory index of the wand, or -999 to select one </param>
[Serializable]
internal class AimWandGameCommand : GameCommand
{
    private AimWandGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'a';

    public override bool Execute()
    {
        SaveGame.DoAimWand();
        return false;
    }
}
