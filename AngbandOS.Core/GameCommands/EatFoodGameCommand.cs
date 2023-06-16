// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Eat some food
/// </summary>
/// <param name="itemIndex"> The inventory index of the food item </param>
[Serializable]
internal class EatFoodGameCommand : GameCommand
{
    private EatFoodGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'E';

    public override bool Execute()
    {
        SaveGame.DoEatCmd();
        return false;
    }
}
