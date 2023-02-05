namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class PantherMonsterRace : MonsterRace
    {
        protected PantherMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'f';
        public override Colour Colour => Colour.Black;
        public override string Name => "Panther";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 8),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A large black cat, stalking you with intent. It thinks you're its next meal.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Panther";
        public override int Hdice => 10;
        public override int Hside => 8;
        public override int LevelFound => 10;
        public override int Mexp => 25;
        public override int NoticeRange => 40;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Panther   ";
    }
}
