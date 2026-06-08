// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PoisonBoltProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "produce poison bolts");
    public override bool UsesPoison => true;
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} casts a poison bolt at {3}";
    public override string? VsPlayerActionMessage => "{0} casts a poison bolt.";
    public override string DamageRollExpression => "12d2+(ML/3)";
    public override string ProjectileKey => nameof(PoisonGasProjectile);
    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.PoisSpellResistantDetection), nameof(SpellResistantDetectionsEnum.ReflectSpellResistantDetection) };
}
