// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NetherBallProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "produce nether balls");
    public override bool UsesNether => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} casts an nether ball at {3}";
    public override string? VsPlayerActionMessage => "{0} casts an nether ball.";
    public override string ProjectileKey => nameof(NetherProjectile);
    public override string DamageRollExpression => "50+10d10+ML";
    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.NethSpellResistantDetection) };
    public override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    public override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    public override bool StopProjectionFlag => false; // Ball projectiles do not stop.
    public override string RadiusExpressionText => "2";
}
