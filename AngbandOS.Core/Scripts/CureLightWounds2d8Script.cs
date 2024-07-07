// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CureLightWounds2d8Script : Script, IScript, INoticeableScript
{
    private CureLightWounds2d8Script(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteNoticeableScript()
    {
        bool noticed = false;
        // Cure light wounds heals you 2d8 health and reduces bleeding
        if (Game.RestoreHealth(Game.DiceRoll(2, 8)))
        {
            noticed = true;
        }
        if (Game.BleedingTimer.AddTimer(-10))
        {
            noticed = true;
        }
        return noticed;
    }

    /// <summary>
    /// Executes the <see cref="INoticeableScript"/> script and returns nothing.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteNoticeableScript();
    }
}
