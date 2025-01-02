// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class JumpToLevelScript : Script, IScript, ICastSpellScript
{
    private JumpToLevelScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the jump to level script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.CommandArgument <= 0)
        {
            string ppp = $"Jump to level (0-{Game.CurDungeon.MaxLevel}): ";
            string def = $"{Game.CurrentDepth}";
            if (!Game.GetString(ppp, out string tmpVal, def, 10))
            {
                return;
            }
            Game.CommandArgument = int.TryParse(tmpVal, out int i) ? i : 0;
        }
        if (Game.CommandArgument < 1)
        {
            Game.CommandArgument = 1;
        }
        if (Game.CommandArgument > Game.CurDungeon.MaxLevel)
        {
            Game.CommandArgument = Game.CurDungeon.MaxLevel;
        }
        Game.MsgPrint($"You jump to dungeon level {Game.CommandArgument}.");
        Game.DoCmdSaveGame(true);
        Game.CurrentDepth = Game.CommandArgument;
        Game.NewLevelFlag = true;
    }
}
