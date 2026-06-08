// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PoisonBallProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "produce poison balls");
    public override bool UsesPoison => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} casts a stinking cloud at {3}";
    public override string? VsPlayerActionMessage => "{0} casts a stinking cloud.";
    public override string ProjectileKey => nameof(PoisonGasProjectile);
    public override string DamageRollExpression => "12d2";
    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.PoisSpellResistantDetection) };
    public override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    public override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    public override bool StopProjectionFlag => false; // Ball projectiles do not stop.
    public override string RadiusExpressionText => "2";
}
