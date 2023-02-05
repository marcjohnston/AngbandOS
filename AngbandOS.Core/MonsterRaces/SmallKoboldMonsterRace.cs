namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SmallKoboldMonsterRace : MonsterRace
    {
        protected SmallKoboldMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'k';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Small kobold";

        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a squat and ugly humanoid figure.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Small kobold";
        public override int Hdice => 2;
        public override int Hside => 7;
        public override bool ImmunePoison => true;
        public override int LevelFound => 1;
        public override int Mexp => 5;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Small    ";
        public override string SplitName3 => "   kobold   ";
    }
}
