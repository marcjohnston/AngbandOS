// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ColdBallProjectileMonsterSpell : ProjectileMonsterSpell
{
    private ColdBallProjectileMonsterSpell(Game game) : base(game) { }
    public override bool UsesCold => true;
    public override bool IsAttack => true;

    public override string? VsMonsterSeenMessage => "{0} casts a frost ball at {3}";
    public override string? VsPlayerActionMessage => "{0} casts a frost ball.";
    protected override string ProjectileKey => nameof(ColdProjectile);
    protected override string DamageRollExpression => "1d(ML*3/2)+10";
    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(ColdSpellResistantDetection) };
    protected override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    protected override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    protected override bool StopProjectionFlag => false; // Ball projectiles do not stop.
    protected override string RadiusExpressionText => "2";
}
