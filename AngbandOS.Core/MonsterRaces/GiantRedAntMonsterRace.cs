namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantRedAntMonsterRace : MonsterRace
    {
        protected GiantRedAntMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'a';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Giant red ant";

        public override bool Animal => true;
        public override int ArmourClass => 34;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 4),
            new MonsterAttack(new StingAttackType(), new LoseStrAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "It is large and has venomous mandibles.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant red ant";
        public override int Hdice => 4;
        public override int Hside => 8;
        public override int LevelFound => 9;
        public override int Mexp => 22;
        public override int NoticeRange => 12;
        public override int Rarity => 2;
        public override int Sleep => 60;
        public override int Speed => 110;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "    red     ";
        public override string SplitName3 => "    ant     ";
        public override bool WeirdMind => true;
    }
}
