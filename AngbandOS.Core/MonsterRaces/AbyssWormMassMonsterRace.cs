using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AbyssWormMassMonsterRace : MonsterRace
    {
        protected AbyssWormMassMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'w';
        public override Colour Colour => Colour.Red;
        public override string Name => "Abyss worm mass";

        public override bool Animal => true;
        public override int ArmourClass => 15;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new CrawlAttackType(), new Exp10AttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "Even more disgusting dark worms, their essence that of unbeing.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Abyss worm mass";
        public override int Hdice => 5;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneFear => true;
        public override bool Invisible => true;
        public override bool KillWall => true;
        public override int LevelFound => 12;
        public override int Mexp => 7;
        public override bool Multiply => true;
        public override int NoticeRange => 10;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override int Sleep => 3;
        public override int Speed => 100;
        public override string SplitName1 => "   Abyss    ";
        public override string SplitName2 => "    worm    ";
        public override string SplitName3 => "    mass    ";
        public override bool Stupid => true;
        public override bool WeirdMind => true;
    }
}
