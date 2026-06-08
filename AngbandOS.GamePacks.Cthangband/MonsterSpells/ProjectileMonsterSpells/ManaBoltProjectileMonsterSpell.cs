// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ManaBoltProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "produce mana bolts");
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} casts a mana bolt at {3}";
    public override string? VsPlayerActionMessage => "{0} casts a mana bolt.";
    public override string DamageRollExpression => "1d(ML*7/2)+50";
    public override string ProjectileKey => nameof(ManaProjectile);
    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.ReflectSpellResistantDetection) };
}
