// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ManaBallProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "invoke mana storms");
    public override bool IsAttack => true;

    /// <summary>
    /// Returns a message that the monster mumbles powerfully.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public override string? VsPlayerBlindMessage => "You hear someone mumble powerfully.";
    public override string? VsPlayerActionMessage => "{0} invokes a mana storm.";
    /// <summary>
    /// Returns a message that the player hears someone powerfully.  The player does not know either monster.
    /// </summary>
    public override string? VsMonsterUnseenMessage => "You hear someone mumble powerfully.";
    public override string? VsMonsterSeenMessage => "{0} invokes a mana storm at {3}";
    public override string ProjectileKey => nameof(ManaProjectile);
    public override string DamageRollExpression => "ML*5+10d10";
    public override string RadiusExpressionText => "4";
    public override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    public override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    public override bool StopProjectionFlag => false; // Ball projectiles do not stop.
}
