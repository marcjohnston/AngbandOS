namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ColdBallMonsterSpell : BallProjectileMonsterSpell
{
    public override bool UsesCold => true;
    public override bool IsAttack => true;

    protected override string ActionName => "casts a frost ball";
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<ColdProjectile>();
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Program.Rng.DieRoll(monsterLevel * 3 / 2) + 10;
    }
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ColdSpellResistantDetection() };
}
