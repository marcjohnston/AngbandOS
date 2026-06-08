// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Arrow3D6ProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("may", "fire arrows");
    public override bool IsInnate => true;
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    /// <summary>
    /// Returns a message that the monster is making some strange noise.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public override string? VsPlayerBlindMessage => "You hear a strange noise.";

    public override string ProjectileKey => nameof(ArrowProjectile);

    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.ReflectSpellResistantDetection) };
    public override string DamageRollExpression => "3d6";
    public override string? VsPlayerActionMessage => "{0} fires an arrow.";
    public override string? VsMonsterSeenMessage => "{0} fires an arrow at {3}";
}
