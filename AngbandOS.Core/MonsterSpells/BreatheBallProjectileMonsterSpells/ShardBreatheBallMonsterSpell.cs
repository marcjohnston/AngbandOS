// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;


[Serializable]
internal class ShardBreatheBallMonsterSpell : BreatheBallProjectileMonsterSpell
{
    private ShardBreatheBallMonsterSpell(Game game) : base(game) { }
    public override bool IsInnate => true;
    public override bool UsesShards => true;
    public override bool IsAttack => true;
    protected override string ActionName => "casts a shard ball";
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Get<Projectile>(nameof(ShardProjectile));
    protected override int MonsterHealthDamageDivisor => 4;
    protected override int MaxDamage => 800;
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.Get<SpellResistantDetection>(nameof(ShardSpellResistantDetection)) };
}
