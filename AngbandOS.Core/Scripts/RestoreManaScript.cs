// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestoreManaScript : Script, IEatOrQuaffScript
{
    private RestoreManaScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        // Restore mana restores your to maximum mana
        if (Game.Mana.IntValue < Game.MaxMana.IntValue)
        {
            Game.Mana.IntValue = Game.MaxMana.IntValue;
            Game.FractionalMana = 0;
            Game.MsgPrint("Your feel your head clear.");
            return new IdentifiedResult(true);
        }
        return new IdentifiedResult(false);
    }
}