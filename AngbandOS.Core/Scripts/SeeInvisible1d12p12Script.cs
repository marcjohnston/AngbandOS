// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SeeInvisible1d12p12Script : Script, INoticeableScript
{
    private SeeInvisible1d12p12Script(Game game) : base(game) { }

    /// <summary>
    /// Adds between 24 and 48 turns of see invisibility.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteNoticeableScript()
    {
        // Detect invisible gives you times see invisibility
        return Game.SeeInvisibilityTimer.AddTimer(12 + Game.DieRoll(12));
    }
}
