// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

/// <summary>
/// Represents a projectile that has no graphics or effect.  This projectile is used by ProjectileScripts that turn pets into unfriendly monsters.
/// </summary>
[Serializable]
internal class NoProjectile : Projectile
{
    private NoProjectile(Game game) : base(game) { } // This object is a singleton.
    protected override string MonsterEffectBindingKey => nameof(NoMonsterEffect);
}