// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Diagnostics;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WalkAndPickupScript : Script, IScript, IGameCommandScript
{
    private WalkAndPickupScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the walk and pickup script and disposes of the repeatable result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the walk and pickup script and returns true, if the walk succeeded or failed due to chance; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        bool isRepeatable = false;

        // If we don't already have a direction, get one
        if (Game.GetDirectionNoAim(out int dir))
        {
            // Walking takes a full turn
            Game.EnergyUse = 100;
            Game.MovePlayer(dir, false);
            isRepeatable = true;
        }
        return new RepeatableResult(isRepeatable);
    }
}
