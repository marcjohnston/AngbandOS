namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheDisenchantMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesDisenchantment => true;
        protected override string ElementName => "disenchantment";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectDisenchant(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 6 > 500 ? 500 : monster.Health / 6;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new DisenSpellResistantDetection() };
    }
}
