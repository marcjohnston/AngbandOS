// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Threading;

namespace AngbandOS.Core.MonsterSpells;

/// <summary>
/// Represents a bolt projectile but also adds a radius damage and uses ball applicable projectile flags.  The messages to the player are also modified.
/// </summary>
[Serializable]
internal abstract class BallProjectileMonsterSpell : ProjectileMonsterSpell
{
    protected BallProjectileMonsterSpell(Game game) : base(game) { }

    protected override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    protected override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    protected override bool StopProjectionFlag => false; // Ball projectiles do not stop.

    /// <summary>
    /// Returns the radius for the ball projectile.  Ball projectiles return 2, by default.
    /// </summary>
    protected override int Radius(Monster monster) => monster.Race.Powerful ? 3 : 2;
}
