// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class DarknessProjectileMonsterSpell : ProjectileMonsterSpell
{
    private DarknessProjectileMonsterSpell(Game game) : base(game) { }
    public override bool Annoys => true;

    protected override bool GridProjectionFlag => true; // Darkness affects the grid.
    protected override bool StopProjectionFlag => false; // Darkness doesn't stop.

    /// <summary>
    /// Returns the grid and kill projectile flags.
    /// </summary>
    public override string? VsMonsterSeenMessage => "{0} gestures in shadow at {3}";
    public override string? VsPlayerActionMessage => "{0} gestures in shadow.";
    protected override string ProjectileKey => nameof(AcidProjectile);
    protected override string DamageRollExpression => "1d(ML*3)+15";
    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(AcidSpellResistantDetection) };

    public override string? PostExecuteOnPlayerScriptBindingKey => nameof(DarknessMonsterSpellOnPlayerPostScript);
    public override string? PostExecuteOnMonsterScriptBindingKey => nameof(DarknessMonsterSpellOnMonsterPostScript);
    protected override bool ItemProjectionFlag => true; // Ball projectiles affect items.
}
