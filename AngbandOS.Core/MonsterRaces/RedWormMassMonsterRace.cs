using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class RedWormMassMonsterRace : MonsterRace
    {
        protected RedWormMassMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'w';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Red worm mass";

        public override bool Animal => true;
        public override int ArmourClass => 12;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new CrawlAttackType(), new FireAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a large slimy mass of worms.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Red worm mass";
        public override int Hdice => 5;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override int LevelFound => 5;
        public override int Mexp => 6;
        public override bool Multiply => true;
        public override int NoticeRange => 7;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 100;
        public override string SplitName1 => "    Red     ";
        public override string SplitName2 => "    worm    ";
        public override string SplitName3 => "    mass    ";
        public override bool Stupid => true;
    }
}
