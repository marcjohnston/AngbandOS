namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BabyRedDragonMonsterRace : MonsterRace
    {
        protected BabyRedDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheFireMonsterSpell());
        public override char Character => 'd';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Baby red dragon";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 3),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 3),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "This hatchling dragon is still soft, its eyes unaccustomed to light and its scales a pale red.";
        public override bool Dragon => true;
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Baby red dragon";
        public override int Hdice => 11;
        public override int Hside => 10;
        public override bool ImmuneFire => true;
        public override int LevelFound => 9;
        public override int Mexp => 35;
        public override int NoticeRange => 20;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 70;
        public override int Speed => 110;
        public override string SplitName1 => "    Baby    ";
        public override string SplitName2 => "    red     ";
        public override string SplitName3 => "   dragon   ";
    }
}
