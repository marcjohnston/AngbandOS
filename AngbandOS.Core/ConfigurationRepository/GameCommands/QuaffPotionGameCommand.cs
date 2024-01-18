// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Quaff a potion from the inventory or the ground
/// </summary>
/// <param name="itemIndex"> The inventory index of the potion to quaff </param>
[Serializable]
internal class QuaffPotionGameCommand : GameCommand
{
    private QuaffPotionGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'q';

    public override bool Execute()
    {
        return SaveGame.RunScript(nameof(QuaffScript));
    }
}
