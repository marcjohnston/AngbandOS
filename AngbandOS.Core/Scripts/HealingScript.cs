// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HealingScript : Script, IScript
{
    private HealingScript(Game game) : base(game) { }

    /// <summary>
    /// Restores 300 points of health and heals stun and bleeding.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.RestoreHealth(300);
        Game.StunTimer.ResetTimer();
        Game.BleedingTimer.ResetTimer();
    }
}
