// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class DisintegrationBreathProjectileMonsterSpell : ProjectileMonsterSpell
{
    private DisintegrationBreathProjectileMonsterSpell(Game game) : base(game) { }
    public override string? VsMonsterSeenMessage => "{0} breathes disintegration at {3}";
    public override string? VsPlayerActionMessage => "{0} breathes disintegration.";
    protected override string ProjectileKey => nameof(DisintegrateProjectile);
    protected override string DamageRollExpression => "MH/3";
    protected override int? MaxDamage => 300;
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
    public override bool InverseRadius => true;
    protected override string RadiusExpressionText => "2";
    protected override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    protected override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    protected override bool StopProjectionFlag => false; // Ball projectiles do not stop.
}
