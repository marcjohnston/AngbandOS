// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ToggleRecallScript : Script, IScript, ICastSpellScript, IActivateItemScript
{
    private ToggleRecallScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        ExecuteScript();
        return new UsedResult(true);
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.WordOfRecallDelay == 0)
        {
            Game.WordOfRecallDelay = Game.DieRoll(20) + 15;
            Game.MsgPrint("The air about you becomes charged...");
        }
        else
        {
            Game.WordOfRecallDelay = 0;
            Game.MsgPrint("A tension leaves the air around you...");
        }
    }
}
