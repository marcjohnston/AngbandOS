// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Ice175R4IdentifableAndUsedScript : Script, IReadScrollOrUseStaffScript
{
    private Ice175R4IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(IceProjectile));
        projectile.TargetedFire(0, 175, 4, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        if (!(Game.ColdResistanceTimer.Value != 0 || Game.HasColdResistance || Game.HasColdImmunity))
        {
            Game.TakeHit(100 + Game.DieRoll(100), "a Scroll of Ice");
        }
        return new IdentifiedAndUsedResult(true, true);
    }
}

