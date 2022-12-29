using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GreenWormMassMonsterRace : MonsterRace
    {
        protected GreenWormMassMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'w';
        public override Colour Colour => Colour.Green;
        public override string Name => "Green worm mass";

        public override bool Animal => true;
        public override int ArmourClass => 3;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new CrawlAttackType(), new AcidAttackEffect(), 1, 3),
        };
        public override string Description => "It is a large slimy mass of worms.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Green worm mass";
        public override int Hdice => 6;
        public override int Hside => 4;
        public override bool HurtByLight => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneFear => true;
        public override int LevelFound => 2;
        public override int Mexp => 3;
        public override bool Multiply => true;
        public override int NoticeRange => 7;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 100;
        public override string SplitName1 => "   Green    ";
        public override string SplitName2 => "    worm    ";
        public override string SplitName3 => "    mass    ";
        public override bool Stupid => true;
        public override bool WeirdMind => true;
    }
}
