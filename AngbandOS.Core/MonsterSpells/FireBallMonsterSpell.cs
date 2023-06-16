namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class FireBallMonsterSpell : BallProjectileMonsterSpell
{
    public override bool UsesFire => true;

    public override bool IsAttack => true;
    protected override string ActionName => "casts a fire ball";
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<FireProjectile>();
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Program.Rng.DieRoll(monsterLevel * 7 / 2) + 10;
    }
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new FireSpellResistantDetection() };
}
