// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

/// <summary>
/// Represents a ball projectile spell but the radius is presented as a negative radius to indicate a cone instead of a ball.  The messages
/// rendered to the player also represent a monster breathe attack.  A monster breathe attack is a ball projectile, but there is no radius of
/// damage.
/// </summary>
[Serializable]
internal abstract class BreatheBallProjectileMonsterSpell : BallProjectileMonsterSpell
{
    protected BreatheBallProjectileMonsterSpell(Game game) : base(game) { }
    /// <summary>
    /// Returns true because all breathe attacks are innate.
    /// </summary>
    public override bool IsInnate => true;

    /// <summary>
    /// Returns true, for all breathe attacks.
    /// </summary>
    public override bool UsesBreathe => true;

    /// <summary>
    /// Returns true because all breathing from a monster is an attack.
    /// </summary>
    public override bool IsAttack => true;

    /// <summary>
    /// Returns a message that the monster breathes.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public override string? VsPlayerBlindMessage => "You hear breathing.";

    /// <summary>
    /// Returns a default radius of damage of 0.
    /// </summary>
    protected override int Radius => 0;

    protected abstract int MonsterHealthDamageDivisor { get; }
    protected abstract int MaxDamage { get; }
    protected sealed override int Damage(Monster monster)
    {
        int damage = monster.Health / MonsterHealthDamageDivisor;
        return damage > MaxDamage ? MaxDamage : damage;
    }

    protected override bool Project(Monster monster, int rad, int y, int x, int dam, Projectile projectile, bool grid, bool stop, bool item, bool kill)
    {
        // Make the radius negative to indicate we need a cone instead of a ball.
        return base.Project(monster, -rad, y, x, dam, projectile, grid: grid, stop: stop, item: item, kill: kill);
    }
}
