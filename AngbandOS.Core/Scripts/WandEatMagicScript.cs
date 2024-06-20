// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WandEatMagicScript : Script, IScriptItem
{
    private WandEatMagicScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptItem(Item item)
    {
        if (item.WandChargesRemaining > 0)
        {
            Game.Mana.IntValue += item.WandChargesRemaining * item.Factory.LevelNormallyFound;
            item.WandChargesRemaining = 0;
        }
        else
        {
            Game.MsgPrint("There's no energy there to absorb!");
        }
        item.IdentEmpty = true;
    }
}
