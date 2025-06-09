// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonRuneScript : Script, IScript, ICastSpellScript
{
    private SummonRuneScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        GridTile tile = Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue];
        Game.MsgPrint("There is a flash of shimmering light!");
        // Trap disappears when triggered
        tile.PlayerMemorized = false;
        Game.RevertTileToBackground(Game.MapY.IntValue, Game.MapX.IntValue);
        // Summon 1d3+2 monsters
        int num = 2 + Game.DieRoll(3);
        for (int i = 0; i < num; i++)
        {
            Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, null, true, false);
        }
        // Have a chance of also cursing the player
        if (Game.Difficulty > Game.DieRoll(100))
        {
            do
            {
                Game.ActivateDreadCurse();
            } while (Game.DieRoll(6) == 1);
        }
    }
}
