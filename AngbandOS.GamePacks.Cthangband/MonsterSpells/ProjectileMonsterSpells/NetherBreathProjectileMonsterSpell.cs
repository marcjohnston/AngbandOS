// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NetherBreathProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("may breathe", "nether");
    public override bool UsesNether => true;
    public override string? VsMonsterSeenMessage => "{0} breathes nether at {3}";
    public override string? VsPlayerActionMessage => "{0} breathes nether.";
    public override string ProjectileKey => nameof(NetherProjectile);
    public override string DamageRollExpression => "MH/6";
    public override int? MaxDamage => 550;
    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.NethSpellResistantDetection) };
    /// <summary>
    /// Returns true because all breathe attacks are innate.
    /// </summary>
    public override bool IsInnate => true;

    /// <summary>
    /// Returns true, for all breathe attacks.
    /// </summary>
    public override bool UsesBreathe => true;

    /// <summary>
    /// Returns true because all breathing from a monster is an attack.
    /// </summary>
    public override bool IsAttack => true;

    /// <summary>
    /// Returns a message that the monster breathes.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public override string? VsPlayerBlindMessage => "You hear breathing.";
    public override bool InverseRadius => true;
    public override string RadiusExpressionText => "2";
    public override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    public override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    public override bool StopProjectionFlag => false; // Ball projectiles do not stop.
}
