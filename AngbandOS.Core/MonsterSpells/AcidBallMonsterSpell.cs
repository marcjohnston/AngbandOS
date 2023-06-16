namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class AcidBallMonsterSpell : BallProjectileMonsterSpell
{
    public override bool UsesAcid => true;
    public override bool IsAttack => true;
    protected override string ActionName => "casts an acid ball";
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<AcidProjectile>();
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Program.Rng.DieRoll(monsterLevel * 3) + 15;
    }
    public override  SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new AcidSpellResistantDetection() };
}
