// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PoisonProjectileUnfriendlyScript : Script, IUnfriendlyScript
{
    private PoisonProjectileUnfriendlyScript(Game game) : base(game) { }

    public bool ExecuteUnfriendlyScript(int who, int y, int x)
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(PoisProjectile));
        projectile.Fire(who, 2, y, x, 3, item: true, kill: true, jump: true, beam: false, thru: false, hide: false, grid: false, stop: false);
        return true;
    }
}
