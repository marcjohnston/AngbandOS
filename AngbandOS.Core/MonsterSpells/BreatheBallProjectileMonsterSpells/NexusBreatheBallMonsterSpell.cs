// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class NexusBreatheBallMonsterSpell : BreatheBallProjectileMonsterSpell
{
    private NexusBreatheBallMonsterSpell(Game game) : base(game) { }
    public override bool UsesNexus => true;
    public override string? VsMonsterSeenMessage => "{0} breathes nexus at {3}";
    public override string? VsPlayerActionMessage => "{0} breathes nexus.";
    protected override string ProjectileKey => nameof(NexusProjectile);
    protected override int MonsterHealthDamageDivisor => 3;
    protected override int MaxDamage => 250;
    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(NexusSpellResistantDetection) };
}
