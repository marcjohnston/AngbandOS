// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ChaosBall222R4IdentifableAndUsedScript : Script, IReadScrollOrUseStaffScript
{
    private ChaosBall222R4IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ProjectileNamesEnum.ChaosProjectile)), 0, 222, 4);
        if (!Game.HasChaosResistance)
        {
            Game.TakeHit(111 + Game.DieRoll(111), "a Scroll of Chaos");
        }
        return new IdentifiedAndUsedResult(true, true);
    }
}

