// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class DarkBreatheBallMonsterSpell : BreatheBallProjectileMonsterSpell
{
    private DarkBreatheBallMonsterSpell(Game game) : base(game) { }
    public override bool UsesDarkness => true;
    public override string? VsMonsterSeenMessage => "{0} breathes darkness at {3}";
    public override string? VsPlayerActionMessage => "{0} breathes darkness.";
    protected override string ProjectileKey => nameof(DarkProjectile);
    protected override int MonsterHealthDamageDivisor => 6;
    protected override int MaxDamage => 400;
    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(DarkSpellResistantDetection) };
}
