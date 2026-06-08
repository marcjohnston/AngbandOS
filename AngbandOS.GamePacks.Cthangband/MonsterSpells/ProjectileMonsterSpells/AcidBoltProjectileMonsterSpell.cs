// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidBoltProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "produce acid bolts");
    public override bool UsesAcid => true;
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} casts an acid bolt at {3}";
    public override string? VsPlayerActionMessage => "{0} casts an acid bolt.";
    public override string DamageRollExpression => "7d8+(ML/3)";
    public override string ProjectileKey => nameof(AcidProjectile);
    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.AcidSpellResistantDetection), nameof(SpellResistantDetectionsEnum.ReflectSpellResistantDetection) };
}
