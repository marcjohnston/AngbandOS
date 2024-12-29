// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class StoneMudScript : Script, IDirectionalCancellableScriptItem
{
    private StoneMudScript(Game game) : base(game) { }

    public bool ExecuteCancellableScriptItem(Item item, int direction) // This is run by an item activation
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(WallToMudProjectile));
        bool hitSuccess = projectile.TargetedFire(direction, 20 + Game.DieRoll(30), 0, grid: true, item: true, kill: true, beam: true, jump: false, stop: false, thru: false, hide: false);
        return true;
    }
}
