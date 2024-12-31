// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ProtectionFromEvilScript : Script, IScript, IUsedScriptItem
{
    private ProtectionFromEvilScript(Game game) : base(game) { }

    public bool ExecuteUsedScriptItem(Item item)
    {
        ExecuteScript();
        return true;
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.ProtectionFromEvilTimer.AddTimer(Game.DieRoll(25) + (3 * Game.ExperienceLevel.IntValue));
    }
}
