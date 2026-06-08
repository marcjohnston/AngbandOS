// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ColdBoltProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "produce frost bolts");
    public override bool UsesCold => true;
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;

    public override string? VsMonsterSeenMessage => "{0} casts a frost bolt at {3}";

    public override string? VsPlayerActionMessage => "{0} casts a frost bolt.";
    public override string DamageRollExpression => "6d8+(ML/3)";
    public override string ProjectileKey => nameof(ColdProjectile);
    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.ColdSpellResistantDetection), nameof(SpellResistantDetectionsEnum.ReflectSpellResistantDetection) };
}
