// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class NetherBreatheBallMonsterSpell : BreatheBallProjectileMonsterSpell
{
    private NetherBreatheBallMonsterSpell(Game game) : base(game) { }
    public override bool UsesNether => true;
    protected override string ElementName => "nether";
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Get<Projectile>(nameof(NetherProjectile));
    protected override int MonsterHealthDamageDivisor => 6;
    protected override int MaxDamage => 550;
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.Get<SpellResistantDetection>(nameof(NethSpellResistantDetection)) };
}
