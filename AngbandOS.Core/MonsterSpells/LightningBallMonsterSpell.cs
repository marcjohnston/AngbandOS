namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class LightningBallMonsterSpell : BallProjectileMonsterSpell
{
    public override bool UsesLightning => true;
    public override bool IsAttack => true;
    protected override string ActionName => "casts a lightning ball";
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<ElecProjectile>();
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Program.Rng.DieRoll(monsterLevel * 3 / 2) + 8;
    }
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ElecSpellResistantDetection() };
}
