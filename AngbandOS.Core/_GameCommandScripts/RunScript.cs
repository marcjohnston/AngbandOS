// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RunScript : GameCommandUniversalScript
{
    private RunScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the run script and returns false, if the player is confused; true, otherwise.
    /// </summary>
    /// <returns></returns>
    public override RepeatableResultEnum ExecuteGameCommandScript()
    {
        // Can't run if we're confused
        if (Game.ConfusionTimer.Value != 0)
        {
            Game.MsgPrint("You are too confused!");
            return RepeatableResultEnum.False; // Don't repeat this.
        }
        // Get a direction if we don't already have one
        if (Game.GetDirectionNoAim(out int dir))
        {
            // If we don't have a distance, assume we'll run for 1,000 steps
            Game.Running = Game.CommandArgument != 0 ? Game.CommandArgument : 1000;
            // Run one step in the chosen direction
            Game.RunOneStep(dir);
        }
        return RepeatableResultEnum.True; // Repeat the run.
    }
}
