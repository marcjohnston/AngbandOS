namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantWhiteCentipedeMonsterRace : MonsterRace
    {
        protected GiantWhiteCentipedeMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'c';
        public override string Name => "Giant white centipede";

        public override bool Animal => true;
        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 2),
            new MonsterAttack(new StingAttackType(), new HurtAttackEffect(), 1, 2),
        };
        public override bool BashDoor => true;
        public override string Description => "It is about four feet long and carnivorous.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant white centipede";
        public override int Hdice => 3;
        public override int Hside => 5;
        public override int LevelFound => 1;
        public override int Mexp => 2;
        public override int NoticeRange => 7;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   white    ";
        public override string SplitName3 => " centipede  ";
        public override bool WeirdMind => true;
    }
}
