// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;


[Serializable]
public class ShardBreathProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("may breathe", "produce shard balls");
    public override bool IsInnate => true;
    public override bool UsesShards => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} casts a shard ball at {3}";
    public override string? VsPlayerActionMessage => "{0} casts a shard ball.";
    public override string ProjectileKey => nameof(ShardProjectile);
    public override string DamageRollExpression => "MH/4";
    public override int? MaxDamage => 800;
    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.ShardSpellResistantDetection) };
    /// <summary>
    /// Returns true, for all breathe attacks.
    /// </summary>
    public override bool UsesBreathe => true;

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
