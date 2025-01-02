// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TargetScript : Script, IScript, IGameCommandScript
{
    private TargetScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the target script and returns false.
    /// </summary>
    /// <returns></returns>
    public GameCommandResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new GameCommandResult(false);
    }

    /// <summary>
    /// Executes the target script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.TargetSet(Constants.TargetKill))
        {
            if (Game.TargetWho != null)
            {
                Game.MsgPrint(Game.TargetWho.SelectionMessage);
            }
        }
        else
        {
            Game.MsgPrint("Target Aborted.");
        }
    }
}
