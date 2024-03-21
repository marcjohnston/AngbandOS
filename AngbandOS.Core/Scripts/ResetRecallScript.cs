// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ResetRecallScript : Script, IScript
{
    private ResetRecallScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        string ppp = $"Reset to which level (1-{Game.CurDungeon.RecallLevel}): ";
        string def = $"{Math.Max(Game.CurrentDepth, 1)}";
        if (!Game.GetString(ppp, out string tmpVal, def, 10))
        {
            return;
        }
        if (!int.TryParse(tmpVal, out int dummy))
        {
            dummy = 1;
        }
        if (dummy < 1)
        {
            dummy = 1;
        }
        if (dummy > Game.CurDungeon.RecallLevel)
        {
            dummy = Game.CurDungeon.RecallLevel;
        }
        Game.MsgPrint($"Recall depth set to level {dummy}.");
    }
}
