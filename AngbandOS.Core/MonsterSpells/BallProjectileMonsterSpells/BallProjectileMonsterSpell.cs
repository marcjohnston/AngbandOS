// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

/// <summary>
/// Represents a bolt projectile but also adds a radius damage and uses ball applicable projectile flags.  The messages to the player are also modified.
/// </summary>
[Serializable]
internal abstract class BallProjectileMonsterSpell : ProjectileMonsterSpell
{
    protected BallProjectileMonsterSpell(Game game) : base(game) { }
    /// <summary>
    /// Returns the radius of the damage.  Returns 2, by default.
    /// </summary>
    protected virtual int Radius => 2;

    protected override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    protected override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    protected override bool StopProjectionFlag => false; // Ball projectiles do not stop.

    protected override IsNoticedEnum Project(Monster monster, int rad, int y, int x, int dam, Projectile projectile, bool grid, bool stop, bool item, bool kill)
    {
        // A ball injects a radius.
        int radius = Radius;

        // Radius 0 means use the default radius
        if (radius < 1)
        {
            radius = monster.Race.Powerful ? 3 : 2; // TODO: This can be a monster setting ... instead of based on Powerful
        }

        return base.Project(monster, rad, y, x, dam, projectile, grid: grid, stop: stop, item: item, kill: kill);
    }
}
