namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class LightningBoltMonsterSpell : BoltProjectileMonsterSpell
    {
        public override bool UsesLightning => true;
        public override bool CanBeReflected => true;
        public override bool IsAttack => true;
        protected override string ActionName => "casts a lightning bolt";
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DiceRoll(4, 8) + (monsterLevel / 3);
        }
        protected override Projectile Projectile(SaveGame saveGame) => new ElecProjectile(saveGame);
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ElecSpellResistantDetection(), new ReflectSpellResistantDetection() };
    }
}
