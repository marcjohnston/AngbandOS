// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class DarkBallProjectileMonsterSpell : ProjectileMonsterSpell
{
    private DarkBallProjectileMonsterSpell(Game game) : base(game) { }
    public override bool UsesDarkness => true;
    public override bool IsAttack => true;

    /// <summary>
    /// Returns a message that the monster mumbles powerfully.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public override string? VsPlayerBlindMessage => "You hear someone mumble powerfully.";
    public override string? VsMonsterSeenMessage => "{0} invokes a darkness storm at {3}";
    public override string? VsPlayerActionMessage => "{0} invokes a darkness storm.";
    protected override string ProjectileKey => nameof(DarknessProjectile);
    protected override string DamageRollExpression => "ML*5+10d10";
    protected override string RadiusExpressionText => "4";
    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(DarkSpellResistantDetection) };
    protected override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    protected override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    protected override bool StopProjectionFlag => false; // Ball projectiles do not stop.
}
