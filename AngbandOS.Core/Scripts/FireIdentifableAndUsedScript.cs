// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class FireIdentifableAndUsedScript : Script, IReadScrollAndUseStaffScript
{
    private FireIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteReadScrollAndUseStaffScript()
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), 0, 150, 4);
        if (!(Game.FireResistanceTimer.Value != 0 || Game.HasFireResistance || Game.HasFireImmunity))
        {
            Game.TakeHit(50 + Game.DieRoll(50), "a Scroll of Fire");
        }
        return (true, true);
    }
}

