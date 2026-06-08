// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaosBallProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "invoke raw chaos");
    /// <summary>
    /// Returns a message that the monster is mumbling something frighteningly.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public override string? VsPlayerBlindMessage => "You hear someone mumble frighteningly.";
    public override string? VsPlayerActionMessage => "{0} invokes raw chaos.";
    public override bool IsInnate => true;
    public override bool UsesChaos => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} invokes raw chaos at {3}";
    public override string ProjectileKey => nameof(ChaosProjectile);
    public override string DamageRollExpression => "ML*2+10d10";
    public override string RadiusExpressionText => "4";
    public override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(SpellResistantDetectionsEnum.ChaosSpellResistantDetection) };
    public override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    public override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    public override bool StopProjectionFlag => false; // Ball projectiles do not stop.
}
