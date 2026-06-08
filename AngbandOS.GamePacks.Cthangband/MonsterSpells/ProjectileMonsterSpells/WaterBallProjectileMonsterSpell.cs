// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WaterBallProjectileMonsterSpell : ProjectileMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "produce water balls");
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} gestures fluidly at {3}";
    public override string? VsPlayerActionMessage => "{0} gestures fluidly.";
    public override string ProjectileKey => nameof(WaterProjectile);
    public override string DamageRollExpression => "1d(ML*5/2)+50";

    public override string? PostExecuteOnPlayerScriptBindingKey => nameof(SystemScriptsEnum.WaterBallMonsterSpellOnPlayerPostScript);
    public override string? PostExecuteOnMonsterScriptBindingKey => nameof(SystemScriptsEnum.WaterBallMonsterSpellOnMonsterPostScript);
    public override bool GridProjectionFlag => true; // Ball projectiles affect the grid.
    public override bool ItemProjectionFlag => true; // Ball projectiles affect items.
    public override bool StopProjectionFlag => false; // Ball projectiles do not stop.
    public override string RadiusExpressionText => "4";
}
