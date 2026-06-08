// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WaterBoltProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "produce water bolts");
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} casts a water bolt at {3}";
    public override string? VsPlayerActionMessage => "{0} casts a water bolt.";
    public override string DamageRollExpression => "10d10+ML";
    public override string ProjectileKey => nameof(WaterProjectile);
    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.ReflectSpellResistantDetection) };
}
