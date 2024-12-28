// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Recharge60IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private Recharge60IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.RunCancellableScriptInt(nameof(RechargeItemScript), 60))
        {
            return (true, false);
        }
        return (true, true);
    }
}

