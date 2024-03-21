// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ShowManualScript : Script, IScript, IRepeatableScript
{
    private ShowManualScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the show manual script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the show manual script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.ShowManual();
    }
}
