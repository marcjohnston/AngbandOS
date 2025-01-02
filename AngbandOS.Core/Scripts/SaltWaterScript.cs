// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SaltWaterScript : Script, IIdentifiedScript
{
    private SaltWaterScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteIdentifiedScript()
    {
        // Salt water makes you vomit, but gets rid of poison
        Game.MsgPrint("The saltiness makes you vomit!");
        Game.SetFood(Constants.PyFoodStarve - 1);
        Game.PoisonTimer.ResetTimer();
        Game.ParalysisTimer.AddTimer(4);
        return new IdentifiedResult(true);
    }
}