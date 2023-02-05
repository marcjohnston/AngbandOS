namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class KillerSlicerBeetleMonsterRace : MonsterRace
    {
        protected KillerSlicerBeetleMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'K';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Killer slicer beetle";

        public override bool Animal => true;
        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 5, 8),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 5, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a beetle with deadly sharp cutting mandibles and a rock-hard carapace.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Killer slicer beetle";
        public override int Hdice => 22;
        public override int Hside => 10;
        public override int LevelFound => 30;
        public override int Mexp => 200;
        public override int NoticeRange => 14;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Killer   ";
        public override string SplitName2 => "   slicer   ";
        public override string SplitName3 => "   beetle   ";
        public override bool WeirdMind => true;
    }
}
