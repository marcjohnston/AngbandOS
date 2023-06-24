// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Use a rod from the inventory or ground
/// </summary>
/// <param name="itemIndex"> The inventory index of the item to be used </param>
[Serializable]
internal class ZapRodGameCommand : GameCommand
{
    private ZapRodGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'z';

    public override bool Execute()
    {
        return SaveGame.RunScript<ZapRodScript>();
    }
}
