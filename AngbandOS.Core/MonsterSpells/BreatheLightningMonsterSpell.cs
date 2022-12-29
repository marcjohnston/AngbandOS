namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BreatheLightningMonsterSpell : BreatheProjectileMonsterSpell
    {
        public override bool UsesLightning => true;
        protected override string ElementName => "lightning";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectElec(saveGame);
        protected override int Damage(Monster monster) => monster.Health / 3 > 1600 ? 1600 : monster.Health / 3;
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new ElecSpellResistantDetection() };
    }
}
