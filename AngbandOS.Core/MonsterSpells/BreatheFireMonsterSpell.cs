namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class BreatheFireMonsterSpell : BreatheProjectileMonsterSpell
{
    public override bool UsesFire => true;
    protected override string ElementName => "fire";
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<FireProjectile>();
    protected override int Damage(Monster monster) => monster.Health / 3 > 1600 ? 1600 : monster.Health / 3;
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new FireSpellResistantDetection() };
}
