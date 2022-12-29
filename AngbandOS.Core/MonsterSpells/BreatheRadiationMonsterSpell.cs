namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheRadiationMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesRadiation => true;
        protected override string ElementName => "toxic waste";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectNuke(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 3 > 800 ? 800 : monster.Health / 3;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new PoisSpellResistantDetection() };
    }
}
